using ConectaCienciaAPI.Model;
using ConectaCienciaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ConectaCienciaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormulariosController : ControllerBase
    {
        private readonly FormularioRepository _formularioRepository;

        public FormulariosController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("conexao");
            _formularioRepository = new FormularioRepository(connectionString);
        }

        [HttpPost("tema")]
        public async Task<IActionResult> AdicionarTema([FromBody] FormulariosModel.FormularioTema formularioTema)
        {
            if (formularioTema == null)
            {
                return BadRequest("Dados do formulário de tema não fornecidos.");
            }

            try
            {
                await _formularioRepository.AdicionarTema(formularioTema);
                return Ok("Sugestão de tema adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar a sugestão de tema: {ex.Message}");
            }
        }

        [HttpPost("artigo")]
        public async Task<IActionResult> AdicionarArtigo([FromBody] FormulariosModel.FormularioArtigo formularioArtigo)
        {
            if (formularioArtigo == null)
            {
                return BadRequest("Dados do formulário de artigo não fornecidos.");
            }

            try
            {
                await _formularioRepository.AdicionarArtigo(formularioArtigo);
                return Ok("Sugestão de artigo adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar a sugestão de artigo: {ex.Message}");
            }
        }
    }
}
