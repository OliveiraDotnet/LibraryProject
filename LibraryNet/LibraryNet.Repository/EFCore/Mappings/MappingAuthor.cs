using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryNet.Repository.Models;

namespace LibraryNet.Repository.EFCore.Mappings
{
    public class MappingAuthor : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(a => a.Name)
                   .HasMaxLength(50);
            builder.HasMany(a => a.Books);
        }
    }
}
