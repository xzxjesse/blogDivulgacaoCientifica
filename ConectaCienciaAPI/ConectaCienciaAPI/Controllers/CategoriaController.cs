using Microsoft.AspNetCore.Mvc;
using ConectaCienciaAPI.Repositories;
using ConectaCienciaAPI.Model;

namespace ConectaCienciaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("conexao");
            _categoriaRepository = new CategoriaRepository(connectionString);
        }

        [HttpGet]
        public IEnumerable<CategoriaModel> Pesquisa()
        {
            return _categoriaRepository.Pesquisa();
        }
    }
}
