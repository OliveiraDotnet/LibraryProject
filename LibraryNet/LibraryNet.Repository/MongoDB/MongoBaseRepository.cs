using MongoDB.Driver;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Repository.MongoDB.Extensions;

namespace LibraryNet.Repository.MongoDB
{
    public abstract class MongoBaseRepository<T> : MongoBaseReadRepository<T>, IWriteRepository<T> where T : IRecordElement
    {
        protected MongoBaseRepository(IMongoClient mongoCliente) : base(mongoCliente)
        {
        }

        public async Task CreateMany(List<T> listaEntidade) => await Collection.InsertManyAsync(listaEntidade);
        public void Update(T entity)
        {
            var filtro = entity.GetIdFilter();
            Collection.ReplaceOne(filtro, entity, new ReplaceOptions() { IsUpsert = true });
        }

        public void Create(T entity) => Collection.InsertOne(entity);
        public async Task CreateAsync(T entity) => await Collection.InsertOneAsync(entity);
        public void Delete(T entity) => Collection.FindOneAndDelete(u => u.Id == entity.Id);
        public async Task DeleteAsync(T entity) => await Collection.FindOneAndDeleteAsync(u => u.Id == entity.Id);
        public async Task UpdateAsync(T entity)
        {
            var filter = entity.GetIdFilter();
            await Collection.FindOneAndReplaceAsync(filter, entity, new FindOneAndReplaceOptions<T, T> { IsUpsert = true });
        }
    }
}