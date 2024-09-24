using ConectaCienciaAPI.Model;
using ConectaCienciaAPI.Models;
using System.Net;
using System.Net.Http.Json;

namespace TesteAPI_ConectaCiencia
{
    public class TestFeed
    {
        private readonly HttpClient _client;

        public TestFeed()
        {
            _client = new HttpClient();
        }

        #region |get|
        [Fact]
        public async Task GetTodosOsArtigos()
        {
            var response = await _client.GetAsync("https://localhost:7259/api/Feed");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var artigos = await response.Content.ReadFromJsonAsync<List<ArtigoModel>>();

            Assert.NotNull(artigos);
            Assert.Equal(4, artigos.Count);
        }

        [Fact]
        public async Task GetArtigosPorPesquisa()
        {
            var textoPesquisa = "climáticas";
            var nomeCategoria = "Biologia";
            var dataPublicacao = "2024-03-10";

            var response = await _client.GetAsync($"https://localhost:7259/api/Feed?textoPesquisa={Uri.EscapeDataString(textoPesquisa)}&nomeCategoria={Uri.EscapeDataString(nomeCategoria)}&dataPublicacao={dataPublicacao}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var artigos = await response.Content.ReadFromJsonAsync<List<ArtigoModel>>();

            Assert.NotNull(artigos);
            Assert.Single(artigos);

            var artigo = artigos[0];
            Assert.Equal("Mudanças Climáticas e Seus Efeitos na Biodiversidade", artigo.Titulo);
            Assert.Equal("Biologia", artigo.Categoria.Nome_Categoria);
            Assert.Equal(DateTime.Parse("2024-03-10T16:00:00"), artigo.Data);
        }

        [Fact]
        public async Task GetArtigosPorUsuario()
        {
            var idUsuario = 2;

            var response = await _client.GetAsync($"https://localhost:7259/api/Feed/MeusArtigos?id_usuario={idUsuario}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var artigos = await response.Content.ReadFromJsonAsync<List<ArtigoModel>>();

            Assert.NotNull(artigos);
            Assert.All(artigos, artigo => Assert.Equal(2, artigo.Usuario.Id_Usuario));
        }

        [Fact]
        public async Task GetArtigoPorId()
        {
            var idArtigo = 1;

            var response = await _client.GetAsync($"https://localhost:7259/api/Feed/Artigo/{idArtigo}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var artigo = await response.Content.ReadFromJsonAsync<ArtigoModel>();

            Assert.NotNull(artigo);

            Assert.Equal(1, artigo.Id_Artigo);
            Assert.Equal("Mudanças Climáticas e Seus Efeitos na Biodiversidade", artigo.Titulo);
            Assert.Equal("As mudanças climáticas estão tendo um impacto significativo sobre a biodiversidade global, afetando habitats, padrões de migração e a sobrevivência de muitas espécies. Este artigo explora como as mudanças no clima estão alterando ecossistemas e quais são as consequências para a fauna e flora. Discutimos também as estratégias para mitigar esses efeitos e promover a conservação da biodiversidade em um mundo em aquecimento.", artigo.Conteudo);

            Assert.Equal(2, artigo.Categoria.Id_Categoria);
            Assert.Equal("Biologia", artigo.Categoria.Nome_Categoria);

            Assert.Equal(2, artigo.Usuario.Id_Usuario);
            Assert.Equal("Maria Souza", artigo.Usuario.Nome);
        }
        #endregion

        #region |post|
        [Fact]
        public async Task PostNovoArtigoComId()
        {
            var novoArtigo = new ArtigoModel
            {
                Id_Artigo = 5,
                Data = DateTime.UtcNow,
                Titulo = "Novo Artigo de Teste com ID 5",
                Conteudo = "Este é o conteúdo de um novo artigo com ID 5.",
                Categoria = new CategoriaModel
                {
                    Id_Categoria = 1,
                    Nome_Categoria = "Física"
                },
                Usuario = new UsuarioSimplificado
                {
                    Id_Usuario = 1,
                    Nome = "João Silva"
                }
            };

            var response = await _client.PostAsJsonAsync("https://localhost:7259/api/Feed/Artigo", novoArtigo);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var artigoCriado = await response.Content.ReadFromJsonAsync<ArtigoModel>();

            Assert.NotNull(artigoCriado);

            Assert.Equal(5, artigoCriado.Id_Artigo);

            Assert.Equal(novoArtigo.Titulo, artigoCriado.Titulo);
            Assert.Equal(novoArtigo.Conteudo, artigoCriado.Conteudo);

            Assert.Equal(novoArtigo.Categoria.Id_Categoria, artigoCriado.Categoria.Id_Categoria);
            Assert.Equal(novoArtigo.Usuario.Id_Usuario, artigoCriado.Usuario.Id_Usuario);
        }
        #endregion

        #region |patch|
        [Fact]
        public async Task PatchAtualizarCategoriaDoArtigo()
        {
            var novaCategoria = new ArtigoModel
            {
                Id_Artigo = 5,
                Data = DateTime.UtcNow,
                Titulo = "Novo Artigo de Teste com ID 5",
                Conteudo = "Este é o conteúdo de um novo artigo com ID 5.",
                Categoria = new CategoriaModel
                {
                    Id_Categoria = 2,
                    Nome_Categoria = "Biologia"
                },
                Usuario = new UsuarioSimplificado
                {
                    Id_Usuario = 1,
                    Nome = "João Silva"
                }
            };

            var response = await _client.PatchAsJsonAsync("https://localhost:7259/api/Feed/Artigo/Patch/5", novaCategoria);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var artigoAtualizado = await _client.GetFromJsonAsync<ArtigoModel>("https://localhost:7259/api/Feed/Artigo/5");

            Assert.NotNull(artigoAtualizado);
            Assert.Equal(2, artigoAtualizado.Categoria.Id_Categoria);
            Assert.Equal("Biologia", artigoAtualizado.Categoria.Nome_Categoria);
        }
        #endregion

        #region |delete|
        [Fact]
        public async Task DeleteArtigoPorId()
        {
            var response = await _client.DeleteAsync("https://localhost:7259/api/Feed/Artigo/Delete/5");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var artigoDeletadoResponse = await _client.GetAsync("https://localhost:7259/api/Feed/Artigo/5");
            Assert.Equal(HttpStatusCode.NotFound, artigoDeletadoResponse.StatusCode);
        }
        #endregion

    }
}
