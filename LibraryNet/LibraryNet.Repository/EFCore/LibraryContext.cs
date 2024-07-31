using LibraryNet.Repository.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MappingBook());
        }
    }
}
