using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Services
{
    public class BookServices : IBookServices
    {
        protected IReadRepository<Book> ReadRepositoryBook { get; }
        protected IWriteRepository<Book> WriteRepositoryBook { get; }
        public BookServices(IReadRepository<Book> readRepositoryBook, IWriteRepository<Book> writeRepositoryBook)
        {
            ReadRepositoryBook = readRepositoryBook;
            WriteRepositoryBook = writeRepositoryBook;
        }
        public async Task CreateAsync(Book book) => await WriteRepositoryBook.CreateAsync(book.Like<Book>());

        public async Task DeleteAsync(string entityId) => await WriteRepositoryBook.DeleteAsync(new Book { Id = entityId });

        public async Task<List<Book>> GetAllAsync() => (await ReadRepositoryBook.GetAllAsync()).Like<List<Book>>();

        public async Task<List<Book>> GetByAuthorAsync(string AuthorId) => (await ReadRepositoryBook.GetBySingleKeyQueryAsync(nameof(Book), nameof(Repository.Models.Book.AuthorId), AuthorId)).Like<List<Book>>();

        public async Task<List<Book>> GetByLiteraryGenreAsync(int literaryGenre) => (await ReadRepositoryBook.GetBySingleKeyQueryAsync(nameof(Book), nameof(Book.Category), literaryGenre)).Like<List<Book>>();

        public async Task UpdateAsync(Book bookVO) => await WriteRepositoryBook.UpdateAsync(bookVO.Like<Book>());
    }
}
