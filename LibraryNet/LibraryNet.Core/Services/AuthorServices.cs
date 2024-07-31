using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Core.Models;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Services
{
    public class AuthorServices : IAuthorServices
    {
        protected IReadRepository<Author> ReadRepositoryAuthor { get; }
        protected IWriteRepository<Author> WriteRepositoryAuthor { get; }
        public AuthorServices(IReadRepository<Author> readRepositoryAuthor, IWriteRepository<Author> writeRepositoryAuthor)
        {
            ReadRepositoryAuthor = readRepositoryAuthor;
            WriteRepositoryAuthor = writeRepositoryAuthor;
        }
        public async Task CreateAsync(Author Author) => await WriteRepositoryAuthor.CreateAsync(Author.Like<Author>());

        public async Task DeleteAsync(string AuthorId) => await WriteRepositoryAuthor.DeleteAsync(new Author { Id = AuthorId });

        public async Task<List<Author>> GetAllAsync() => (await ReadRepositoryAuthor.GetAllAsync()).Like<List<Author>>();

        public async Task UpdateAsync(Author Author) => await WriteRepositoryAuthor.UpdateAsync(Author.Like<Author>());
    }
}
