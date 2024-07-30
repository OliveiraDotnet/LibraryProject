using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
    }
}
