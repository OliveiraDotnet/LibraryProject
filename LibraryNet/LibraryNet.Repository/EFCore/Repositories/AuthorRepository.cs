using LibraryNet.Repository.Models;

namespace LibraryNet.Repository.EFCore.Repositories
{
    public class AuthorRepository : EFCoreRepository<Author>
    {
        public AuthorRepository(LibraryContext context) : base(context)
        {
        }
    }
}
