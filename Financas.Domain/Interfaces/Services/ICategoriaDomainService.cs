using Financas.Domain.Dtos;

namespace Financas.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface de serviços de domínio para a entidade Categoria
    /// </summary>
    public interface ICategoriaDomainService
    {
        Task<Guid> Criar(CriarCategoriaDto dto, Guid autorId);

        Task<List<DadosCategoriaDto>> Consultar();
    }
}
