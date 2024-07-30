using LibraryNet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public class EFCoreRepositoryRead<TEntity, TContext> : IReadRepository<TEntity>
    where TEntity : class, IRecordElement
    where TContext : DbContext
    {
        protected DbContext Context { get; }

        protected EFCoreRepositoryRead(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}