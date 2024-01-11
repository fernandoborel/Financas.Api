using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Models;
using MongoDB.Driver;

namespace Financas.Infra.Data.Repositories
{
    public class OperacoesContaRepository : BaseRepository<OperacoesConta>, IOperacoesContaRepository
    {
        private readonly IMongoCollection<OperacoesConta> _operacoesContaCollection;

        public OperacoesContaRepository(IMongoDatabase database) : base(database)
        {
            _operacoesContaCollection = database.GetCollection<OperacoesConta>("OperacoesConta");
        }

        public async Task<string> Sacar(int valor)
        {
            var filter = Builders<OperacoesConta>.Filter.Empty;
            var update = Builders<OperacoesConta>.Update.Inc(x => x.Sacar, valor);

            var options = new FindOneAndUpdateOptions<OperacoesConta>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedConta = await _operacoesContaCollection.FindOneAndUpdateAsync(filter, update, options);
            return updatedConta?.Id.ToString();
        }


        public async Task<Guid> Depositar(int valor, Guid objectId)
        {
            var filter = Builders<OperacoesConta>.Filter.Eq(x => x.Id, objectId);

            var update = Builders<OperacoesConta>.Update.Inc(x => x.Depositar, valor);

            var options = new FindOneAndUpdateOptions<OperacoesConta>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedConta = await _operacoesContaCollection.FindOneAndUpdateAsync(filter, update, options);

            if (updatedConta != null)
            {
                return updatedConta.Id;
            }

            // Tratar o caso em que a conta não foi encontrada
            throw new InvalidOperationException("Erro ao depositar. Conta não encontrada.");
        }


        public async Task<int> ConsultarSaldo()
        {
            var totalDeposito = await _operacoesContaCollection.Aggregate()
                .Group(x => 1, g => new { Total = g.Sum(x => x.Depositar) })
                .FirstOrDefaultAsync();

            var totalSaque = await _operacoesContaCollection.Aggregate()
                .Group(x => 1, g => new { Total = g.Sum(x => x.Sacar) })
                .FirstOrDefaultAsync();

            // O saldo é a diferença entre os depósitos e saques
            int saldo = (totalDeposito?.Total ?? 0) - (totalSaque?.Total ?? 0);

            return saldo;
        }

        public Task<Guid> Sacar(int valor, string objectId)
        {
            throw new NotImplementedException();
        }

        public async override Task UpdateAsync(OperacoesConta model)
        {
            var filter = Builders<OperacoesConta>.Filter.Eq(x => x.Id, model.Id);

            var result = await _operacoesContaCollection.ReplaceOneAsync(filter, model);

            if (result.ModifiedCount == 0)
            {
                // Tratar o caso em que o documento não foi encontrado
                throw new InvalidOperationException("Erro ao atualizar. Documento não encontrado.");
            }
        }
    }
}
