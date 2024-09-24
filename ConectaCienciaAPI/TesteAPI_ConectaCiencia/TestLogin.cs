using System.Net;
using System.Text;
using System.Text.Json;

namespace TesteAPI_ConectaCiencia
{
    public class TestLogin
    {
        private readonly HttpClient _client;

        public TestLogin()
        {
            _client = new HttpClient();
        }

        [Fact]
        public async Task PostCadastroNovoUsuario()
        {
            var novoUsuario = new
            {
                Id_Usuario = 6,
                Nome = "Teste",
                Email = "testeusuario@example.com",
                Senha = "senhaSegura123"
            };

            var jsonContent = JsonSerializer.Serialize(novoUsuario);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://localhost:7259/api/Login/cadastro", content);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var responseString = await response.Content.ReadAsStringAsync();
            var usuarioCadastrado = JsonSerializer.Deserialize<dynamic>(responseString);

            Assert.NotNull(usuarioCadastrado);
        }

        [Fact]
        public async Task GetLoginUsuario()
        {
            var email = "testeusuario@example.com";
            var senha = "senhaSegura123";

            var response = await _client.GetAsync($"https://localhost:7259/api/Login/login?email={email}&senha={senha}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
