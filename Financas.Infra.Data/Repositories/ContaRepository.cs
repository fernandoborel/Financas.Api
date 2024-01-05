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

        public async Task<Conta> GetAsync(string login)
        {
            var filter = Builders<Conta>.Filter.Eq("Login", login);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Conta> GetAsync(string login, string senha)
        {
            var filter = Builders<Conta>.Filter.Eq("Login", login)
                & Builders<Conta>.Filter.Eq("Senha", senha);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
