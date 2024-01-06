using Financas.Domain.Dtos;
using Financas.Domain.Models;

namespace Financas.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para Categoria
    /// </summary>
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task <List<DadosCategoriaDto>> GetAllAsync();
    }
}
