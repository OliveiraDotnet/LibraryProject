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
                   .HasMaxLength(100)
                   .IsRequired(true);

            builder.HasMany(a => a.Books)
                   .WithOne(a => a.Author)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
