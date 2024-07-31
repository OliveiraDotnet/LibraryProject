namespace LibraryNet.Core.Interfaces.Services
{
    public interface IServiceBase<T>
    {
        Task<List<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string entityId);
    }
}
