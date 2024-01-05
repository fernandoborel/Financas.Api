using Financas.Api.Security;
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
        private readonly JwtBearerSecurity _jwtBearerSecurity;

        //construtor
        public ContasController(IContaDomainService contaDomainService, JwtBearerSecurity jwtBearerSecurity)
        {
            _contaDomainService = contaDomainService;
            _jwtBearerSecurity = jwtBearerSecurity;
        }

        [HttpPost("criar")]//api/contas/criar
        public async Task<IActionResult> Criar([FromForm] CriarContaDto dto)
        {
            var id = await _contaDomainService.Criar(dto);
            return StatusCode(201, new
            {
                mensagem = "Conta cadastrada com sucesso!",
                id
            });
        }

        [HttpPost("autenticar")] //api/contas/autenticar
        public async Task<IActionResult> Autenticar([FromBody] AutenticarContaDto dto)
        {
            var result = await _contaDomainService.Autenticar(dto);

            return StatusCode(200, new
            {
                mensagem = "Pessoa autenticada com sucesso!",
                result,
                accessToken = _jwtBearerSecurity.GenerateToken(result.Id.Value),
                expiration = _jwtBearerSecurity.GetExpiration()
            });
        }
    }
}
