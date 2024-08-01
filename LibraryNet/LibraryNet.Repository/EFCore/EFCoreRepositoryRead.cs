using LibraryNet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ResourcesText = LibraryNet.Repository.Properties.Resources;

namespace LibraryNet.Repository.EFCore
{
    public class EFCoreRepositoryRead<TEntity> : IReadRepository<TEntity> where TEntity : class, IRecordElement
    {
        protected virtual DbContext Context { get; }

        protected EFCoreRepositoryRead(DbContext context)
        {
            Context = context;
        }
        public async Task<TEntity> GetByIdAsync(string id) => await Context.Set<TEntity>().FindAsync(id);
        public async Task<List<TEntity>> GetBySingleKeyQueryAsync(string table, string column, object key)
        {
            FormattableString query = $"{string.Format(ResourcesText.BasicQuerySQL, table, column, key)}";
            var entities = await Context.Set<TEntity>().FromSql(query)
                                                       .ToListAsync();
            return entities;
        }
        public async Task<List<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();
    }
}