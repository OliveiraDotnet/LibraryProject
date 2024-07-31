using LibraryNet.Core.Models;

namespace LibraryNet.Core.Interfaces.Services
{
    public interface IBookServices : IServiceBase<Book>
    {
        Task<List<Book>> GetByAuthorAsync(string AuthorId);
        Task<List<Book>> GetByLiteraryGenreAsync(int literaryGenre);
    }
}
