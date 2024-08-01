using LibraryNet.Repository.Models;

namespace LibraryNet.Repository.EFCore.Repositories
{
    public class BookRepository : EFCoreRepository<Book>
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}
