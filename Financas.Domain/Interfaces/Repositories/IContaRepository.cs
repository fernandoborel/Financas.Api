using Financas.Domain.Models;

namespace Financas.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para Conta 
    /// </summary>
    public interface IContaRepository : IBaseRepository<Conta>
    {
        /// <summary>
        /// buscar o login
        /// </summary>
        Task<Conta> GetAsync(string login);

        /// <summary>
        /// buscar o usuário
        /// </summary>
        Task<Conta> GetAsync(string login, string senha);
    }
}
