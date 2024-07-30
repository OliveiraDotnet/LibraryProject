using LibraryNet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public abstract class EFCoreRepository<TEntity, TContext> : EFCoreRepositoryRead<TEntity, TContext>, IWriteRepository<TEntity>
    where TEntity : class, IRecordElement
    where TContext : DbContext
    {
        public EFCoreRepository(TContext context) : base(context)
        {
        }

        public void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public async Task CreateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
    }
}
