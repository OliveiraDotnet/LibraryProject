namespace LibraryNet.Repository.Interfaces
{
    public interface IReadRepository<T>
    {
        Task<List<T>> GetBySingleKeyQueryAsync(string table, string column, object key);
        Task<List<T>> GetAllAsync();
    }
}