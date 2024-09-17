using Microsoft.AspNetCore.Mvc;
using API_ProjetoFinal_DotNET.Repositories;
using API_ProjetoFinal_DotNET.Models;
using System.Collections.Generic;

namespace API_ProjetoFinal_DotNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaController(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoriaModel>> Get()
        {
            try
            {
                var categorias = _categoriaRepository.ObterTodasCategorias();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
