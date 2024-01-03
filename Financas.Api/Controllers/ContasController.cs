using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        //atributo
        private readonly IContaDomainService _contaDomainService;

        //construtor
        public ContasController(IContaDomainService contaDomainService)
        {
            _contaDomainService = contaDomainService;
        }

        [HttpPost("criar")]//api/contas/criar
        public async Task<IActionResult> Criar(CriarContaDto dto)
        {
            var id = await _contaDomainService.Criar(dto);
            return StatusCode(201, new
            {
                mensagem = "Conta cadastrada com sucesso!",
                id
            });
        }
    }
}
