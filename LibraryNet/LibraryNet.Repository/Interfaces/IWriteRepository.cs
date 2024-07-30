namespace LibraryNet.Repository.Interfaces
{
    public interface IWriteRepository<T>
    {
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}