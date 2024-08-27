using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Core.Models;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Utils.Extensions;
using ResourcesCore = LibraryNet.Core.Properties.Resources;

namespace LibraryNet.Core.Services
{
    public class BookServices : IBookServices
    {
        protected IReadRepository<Repository.Models.Book> ReadRepositoryBook { get; }
        protected IWriteRepository<Repository.Models.Book> WriteRepositoryBook { get; }
        public BookServices(IReadRepository<Repository.Models.Book> readRepositoryBook, IWriteRepository<Repository.Models.Book> writeRepositoryBook)
        {
            ReadRepositoryBook = readRepositoryBook;
            WriteRepositoryBook = writeRepositoryBook;
        }
        public async Task CreateAsync(Book book) => await WriteRepositoryBook.CreateAsync(book.Like<Repository.Models.Book>());
        public async Task DeleteAsync(string entityId) => await WriteRepositoryBook.DeleteAsync(new Repository.Models.Book { Id = entityId });
        public async Task<List<Book>> GetAllAsync() => (await ReadRepositoryBook.GetAllAsync()).Like<List<Book>>();
        public async Task<List<Book>> GetByAuthorAsync(string authorId) => (await ReadRepositoryBook.GetBySingleKeyQueryAsync(ResourcesCore.NameTableBook, nameof(Repository.Models.Book.AuthorId), authorId)).Like<List<Book>>();
        public async Task<List<Book>> GetByLiteraryGenreAsync(int literaryGenre) => (await ReadRepositoryBook.GetBySingleKeyQueryAsync(ResourcesCore.NameTableBook, nameof(Book.Category), literaryGenre)).Like<List<Book>>();
        public async Task<List<Book>> GetByPublisherAsync(string publisherId) => (await ReadRepositoryBook.GetBySingleKeyQueryAsync(ResourcesCore.NameTableBook, nameof(Repository.Models.Book.PublisherId), publisherId)).Like<List<Book>>();
        public async Task UpdateAsync(Book bookVO) => await WriteRepositoryBook.UpdateAsync(bookVO.Like<Repository.Models.Book>());

    }
}
