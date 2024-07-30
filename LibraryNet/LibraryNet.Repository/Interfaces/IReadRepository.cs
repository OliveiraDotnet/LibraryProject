namespace LibraryNet.Repository.Interfaces
{
    public interface IReadRepository<T>
    {
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
    }
}