using Financas.Api.Security;
using Financas.Domain.Dtos;
using Financas.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OperacoesContaController : ControllerBase
    {
        private readonly IOperacoesDomainService _operacoesDomainService;

        public OperacoesContaController(IOperacoesDomainService operacoesDomainService)
        {
            _operacoesDomainService = operacoesDomainService;
        }

        [HttpPost("sacar")]
        public async Task<IActionResult> Sacar([FromBody] SacarValorDto dto)
        {
            var id = await _operacoesDomainService.Sacar(dto);
            return Ok(new { Id = id, Message = "Saque realizado com sucesso." });
        }

        [HttpPost("depositar")]
        public async Task<IActionResult> Depositar([FromBody] DepositarValorDto dto)
        {
            var id = await _operacoesDomainService.Depositar(dto);
            return Ok(new { Id = id, Message = "Depósito realizado com sucesso." });
        }

        [HttpGet("consultar")]
        public async Task<IActionResult> Consultar()
        {
            var saldo = await _operacoesDomainService.ConsultarValor();
            return Ok(new { Saldo = saldo, Message = "Consulta realizada com sucesso." });
        }
    }
}
