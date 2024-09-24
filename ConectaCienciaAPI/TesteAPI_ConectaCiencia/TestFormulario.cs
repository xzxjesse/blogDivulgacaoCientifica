using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace TesteAPI_ConectaCiencia
{
    public class TestFormulario
    {
        private readonly HttpClient _client;

        public TestFormulario()
        {
            _client = new HttpClient();
        }

        [Fact]
        public async Task PostSugestaoArtigo()
        {
            var sugestaoArtigo = new
            {
                IdSugestaoArtigo = 6,
                Nome = "Teste",
                Email = "testeusuario@example.com",
                Titulo = "Título do Artigo",
                Conteudo = "Conteúdo do artigo...",
                Id_Categoria = 1,
                Categoria = new
                {
                    Id_Categoria = 1,
                    Nome_Categoria = "Biologia"
                }
            };

            var jsonContent = JsonSerializer.Serialize(sugestaoArtigo);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7259/api/Formularios/artigo", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var artigoRetornado = JsonSerializer.Deserialize<dynamic>(responseString);

            Assert.NotNull(artigoRetornado);
            Assert.Equal("Título do Artigo", (string)artigoRetornado.titulo);
            Assert.Equal("Conteúdo do artigo...", (string)artigoRetornado.conteudo);
        }

        [Fact]
        public async Task PostSugestaoTema()
        {
            var sugestaoTema = new
            {
                IdSugestaoTema = 6,
                Nome = "Teste",
                Email = "testeusuario@example.com",
                Tema = "Tema de Sugestão",
                Id_Categoria = 1,
                Categoria = new
                {
                    Id_Categoria = 1,
                    Nome_Categoria = "Biologia"
                }
            };

            var jsonContent = JsonSerializer.Serialize(sugestaoTema);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7259/api/Formularios/tema", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var temaRetornado = JsonSerializer.Deserialize<dynamic>(responseString);

            Assert.NotNull(temaRetornado);
            Assert.Equal("Tema de Sugestão", (string)temaRetornado.tema);
        }
    }
}
