using LibraryNet.Repository.EFCore.Mappings;
using LibraryNet.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MappingBook())
                        .ApplyConfiguration(new MappingCoupon())
                        .ApplyConfiguration(new MappingAuthor())
                        .ApplyConfiguration(new MappingPublisher());
        }
    }
}
