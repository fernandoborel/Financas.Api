
using Financas.Domain.Dtos;

namespace Financas.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de operações de conta
    /// </summary>
    public interface IOperacoesDomainService
    {
        Task<Guid> Sacar(SacarValorDto dto);
        Task<Guid> Depositar(DepositarValorDto dto);

        Task<int> ConsultarValor();
    }
}
