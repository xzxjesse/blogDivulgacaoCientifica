using Microsoft.AspNetCore.Mvc;
using ConectaCienciaAPI.Model;
using ConectaCienciaAPI.Repositories;
using System.Collections.Generic;
using ConectaCienciaAPI.Models;

namespace ConectaCienciaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedController : ControllerBase
    {
        private readonly FeedRepository _feedRepository;

        public FeedController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("conexao");
            _feedRepository = new FeedRepository(connectionString);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArtigoModel>> Pesquisa([FromQuery] string textoPesquisa = null, [FromQuery] string nomeCategoria = null, [FromQuery] DateTime? dataPublicacao = null)
        {
            try
            {
                var artigos = _feedRepository.Pesquisa(textoPesquisa, nomeCategoria, dataPublicacao);
                if (artigos == null || !artigos.Any())
                {
                    return NotFound("Nenhum artigo encontrado.");
                }
                return Ok(artigos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os artigos: {ex.Message}");
            }
        }
    }
}
