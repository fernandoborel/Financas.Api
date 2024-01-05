using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpPost("criar")]//api/categorias/criar
        public IActionResult Criar()
        {
            return Ok();
        }
        
        [HttpGet("obter-todos")]//api/categorias/obter-todos
        public IActionResult ObterTodos()
        {
            return Ok();
        }
    }
}
