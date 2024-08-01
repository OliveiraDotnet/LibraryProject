using LibraryNet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public abstract class EFCoreRepository<TEntity> : EFCoreRepositoryRead<TEntity>, IWriteRepository<TEntity> where TEntity : class, IRecordElement
    {
        protected EFCoreRepository(DbContext contexto) : base(contexto)
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
