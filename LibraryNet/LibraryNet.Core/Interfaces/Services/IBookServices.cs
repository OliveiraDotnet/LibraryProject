using LibraryNet.Core.Enums;
using LibraryNet.Core.Models.VO;

namespace LibraryNet.Core.Interfaces.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<BookVO>> GetAll();
        Task<IEnumerable<BookVO>> GetByAuthor(string AuthorId);
        Task<IEnumerable<BookVO>> GetByLiteraryGenre(LiteraryGenre literaryGenre);
    }
}
