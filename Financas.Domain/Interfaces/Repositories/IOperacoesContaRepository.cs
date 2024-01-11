using MongoDB.Bson;

namespace Financas.Domain.Interfaces.Repositories
{
    public interface IOperacoesContaRepository
    {
        Task<Guid> Sacar(int valor, string objectId);
        Task<Guid> Depositar(int valor, Guid objectId);
        Task<int> ConsultarSaldo();
    }
}
