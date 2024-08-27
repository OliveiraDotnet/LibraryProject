using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryNet.Repository.Models;

namespace LibraryNet.Repository.EFCore.Mappings
{
    public class MappingBook : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Name)
                   .HasMaxLength(100)
                   .IsRequired(true);

            builder.Property(b => b.Category)
                   .IsRequired(true);

            builder.Property(b => b.Price)
                   .HasColumnType("decimal")
                   .IsRequired(true);

            builder.HasOne(p => p.Author)
                   .WithMany(p => p.Books);

            builder.HasOne(p => p.Publisher)
                   .WithMany(p => p.Books);
        }
    }
}
