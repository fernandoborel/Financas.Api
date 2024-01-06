using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaDomainService _categoriaDomainService;

        public CategoriasController(ICategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        [HttpPost("criar")]//api/categorias/criar
        public async Task<IActionResult> Criar([FromBody] CriarCategoriaDto dto)
        {
            var autorId = User.Identity.Name;

            var id = await _categoriaDomainService.Criar(dto, Guid.Parse(autorId));

            return StatusCode(201, new
            {
                mensagem = "Categoria cadastrada com sucesso!",
                id
            });
        }
        
        [HttpGet("obter-todos")]//api/categorias/obter-todos
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _categoriaDomainService.Consultar();
            return StatusCode(200, result);
        }
    }
}
