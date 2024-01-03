using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Models;
using MongoDB.Driver;

namespace Financas.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Conta
    /// </summary>
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        //construtor
        public ContaRepository(IMongoDatabase database) : base(database) { }
    }
}
