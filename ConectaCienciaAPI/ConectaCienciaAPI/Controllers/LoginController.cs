using Microsoft.AspNetCore.Mvc;
using ConectaCienciaAPI.Model;
using ConectaCienciaAPI.Repositories;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ConectaCienciaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("conexao");
            _usuarioRepository = new UsuarioRepository(connectionString);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return BadRequest("E-mail e senha são obrigatórios.");
            }

            try
            {
                var users = _usuarioRepository.ObterUsuariosPorEmailESenha(email, senha);
                if (users.Any())
                {
                    return Ok(users);
                }
                return Unauthorized("E-mail ou senha inválidos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost("cadastro")]
        public ActionResult<UsuarioModel> Register([FromBody] UsuarioModel usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
            {
                return BadRequest("Nome, e-mail e senha são obrigatórios.");
            }

            try
            {
                _usuarioRepository.AdicionarUsuario(usuario);
                return CreatedAtAction(nameof(Login), new { email = usuario.Email }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
