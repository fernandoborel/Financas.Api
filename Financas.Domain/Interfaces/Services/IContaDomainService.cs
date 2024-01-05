using Financas.Domain.Dtos;

namespace Financas.Domain.Interfaces.Services
{
    public interface IContaDomainService
    {
        /// <summary>
        /// Método para criar uma conta
        /// </summary>
        Task<Guid> Criar(CriarContaDto dto);

        Task<DadosContaDto> Autenticar(AutenticarContaDto dto);
    }
}
