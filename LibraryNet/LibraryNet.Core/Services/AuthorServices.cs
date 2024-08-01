using LibraryNet.Core.Interfaces.Services;
using LibraryNet.Repository.Interfaces;
using LibraryNet.Core.Models;
using LibraryNet.Utils.Extensions;

namespace LibraryNet.Core.Services
{
    public class AuthorServices : IAuthorServices
    {
        protected IReadRepository<Repository.Models.Author> ReadRepositoryAuthor { get; }
        protected IWriteRepository<Repository.Models.Author> WriteRepositoryAuthor { get; }
        public AuthorServices(IReadRepository<Repository.Models.Author> readRepositoryAuthor, IWriteRepository<Repository.Models.Author> writeRepositoryAuthor)
        {
            ReadRepositoryAuthor = readRepositoryAuthor;
            WriteRepositoryAuthor = writeRepositoryAuthor;
        }
        public async Task<List<Author>> GetAllAsync() => (await ReadRepositoryAuthor.GetAllAsync()).Like<List<Author>>();
        public async Task CreateAsync(Author Author) => await WriteRepositoryAuthor.CreateAsync(Author.Like<Repository.Models.Author>());
        public async Task DeleteAsync(string AuthorId) => await WriteRepositoryAuthor.DeleteAsync(new Repository.Models.Author { Id = AuthorId });
        public async Task UpdateAsync(Author Author) => await WriteRepositoryAuthor.UpdateAsync(Author.Like<Repository.Models.Author>());
    }
}
