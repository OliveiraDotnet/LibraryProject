using LibraryNet.Core.Enums;
using LibraryNet.Core.Models;
using LibraryNet.Core.Models.VO;

namespace LibraryNet.Core.Interfaces.Services
{
    public interface IAuthorServices
    {
        Task<IEnumerable<Author>> GetAll();
        Task<IEnumerable<BookVO>> GetByAuthor(string AuthorId);
        Task<IEnumerable<BookVO>> GetByLiteraryGenre(LiteraryGenre literaryGenre);
    }
}
