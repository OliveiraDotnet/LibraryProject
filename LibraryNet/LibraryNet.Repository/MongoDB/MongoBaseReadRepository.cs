using LibraryNet.Repository.Interfaces;
using MongoDB.Driver;

namespace LibraryNet.Repository.MongoDB
{
    public abstract class MongoBaseReadRepository<T> : IReadRepository<T> where T : IRecordElement
    {
        protected readonly IMongoClient client;
        protected readonly IMongoDatabase db;
        protected virtual IMongoCollection<T> Collection => db.GetCollection<T>(CollectionName);
        protected abstract string BaseName { get; }
        protected abstract string CollectionName { get; }

        protected MongoBaseReadRepository(IMongoClient mongoCliente)
        {
            client = mongoCliente;
            db = client.GetDatabase(BaseName);
        }

        public bool Exist(string id)
        {
            var r = Collection.Find(i => i.Id == id).Any();
            return r;
        }
        public async Task<bool> ExistAsync(string id)
        {
            var f = await Collection.FindAsync(i => i.Id == id);
            var r = await f.AnyAsync();
            return r;
        }
        public T GetById(string id)
        {
            var r = Collection.Find(i => i.Id == id);
            return r.FirstOrDefault();
        }
        public async Task<T> GetByIdAsync(string id)
        {
            var r = await Collection.FindAsync(i => i.Id == id);
            return r.FirstOrDefault();
        }
        public virtual IOrderedQueryable<T> OrderByDefault(IQueryable<T> query) => query.OrderBy(u => u.Id);
        public Task<List<T>> GetAllAsync()
        {
            var r = Collection.Find(i => true);
            return Task.FromResult(r.ToList());
        }
        public Task<List<T>> GetBySingleKeyQueryAsync(string table, string column, object key)
        {
            throw new NotImplementedException();
        }
    }
}