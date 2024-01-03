using Financas.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace Financas.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados Genéricos
    /// </summary>
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        //atributo
        protected readonly IMongoCollection<TModel> Collection;

        //construtor
        protected BaseRepository(IMongoDatabase database)
        {
            Collection = database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public virtual async Task AddAsync(TModel model)
        {
            await Collection.InsertOneAsync(model);   
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            var filter = Builders<TModel>.Filter.Eq("_id", GetModelId(model));
            await Collection.ReplaceOneAsync(filter, model);
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            var filter = Builders<TModel>.Filter.Eq("_id", GetModelId(model));
            await Collection.DeleteOneAsync(filter);
        }

        public virtual async Task<TModel> GetByIdAsync(Guid id)
        {
            var filter = Builders<TModel>.Filter.Eq("_id", id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        private static Guid? GetModelId(TModel model)
        {
            var property = typeof(TModel).GetProperty("Id");
            var id = (Guid?)property?.GetValue(model, null);
            return id;
        }
    }
}
