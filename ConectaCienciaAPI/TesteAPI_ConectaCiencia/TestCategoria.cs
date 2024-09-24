using ConectaCienciaAPI.Model;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class TestCategoria
{
    private readonly HttpClient _client;

    public TestCategoria()
    {
        _client = new HttpClient();
    }

    [Fact]
    public async Task GetTodasAsCategorias()
    {
        var response = await _client.GetAsync("https://localhost:7259/api/Categoria");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var categorias = await response.Content.ReadFromJsonAsync<List<CategoriaModel>>();

        Assert.NotNull(categorias);
        Assert.True(categorias.Any());
    }
}
