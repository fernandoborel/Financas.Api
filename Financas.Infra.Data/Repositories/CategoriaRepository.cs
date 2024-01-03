using Financas.Domain.Interfaces.Repositories;
using Financas.Domain.Models;
using MongoDB.Driver;

namespace Financas.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Categoria
    /// </summary>
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        //construtor
        public CategoriaRepository(IMongoDatabase database) : base(database) { }
    }
}
