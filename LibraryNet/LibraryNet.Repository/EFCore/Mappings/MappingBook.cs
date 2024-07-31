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
                   .HasMaxLength(50);
            builder.Property(b => b.Category)
                   .HasMaxLength(50);
            builder.Property(b => b.Price)
                   .HasColumnType("decimal");
            

        }
    }
}
