using ConectaCienciaAPI.Model;
using ConectaCienciaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("login")]
    public ActionResult<int> Login(string email, string senha)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
        {
            return BadRequest("E-mail e senha são obrigatórios.");
        }

        try
        {
            var user = _usuarioRepository.ObterUsuarioPorEmailESenha(email, senha);
            if (user != null)
            {
                return Ok(user.Id_Usuario);
            }
            return Unauthorized("E-mail ou senha inválidos.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
        }
    }

    [HttpPost("cadastro")]
    public ActionResult<int> Register([FromBody] UsuarioModel usuario)
    {
        if (usuario == null || string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
        {
            return BadRequest("Nome, e-mail e senha são obrigatórios.");
        }

        try
        {
            var idUsuario = _usuarioRepository.AdicionarUsuario(usuario);
            return CreatedAtAction(nameof(Login), new { email = usuario.Email }, idUsuario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
        }
    }
}
