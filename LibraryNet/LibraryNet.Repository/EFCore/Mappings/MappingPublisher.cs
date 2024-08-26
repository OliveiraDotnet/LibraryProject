using LibraryNet.Repository.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore.Mappings
{
    public class MappingPublisher : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Name)
                   .HasMaxLength(20)
                   .IsRequired(true);
            builder.Property(b => b.Phone)
                   .HasMaxLength(20);
            builder.Property(b => b.WebSite)
                   .HasMaxLength(100);
            builder.HasMany(pc => pc.Books);
        }
    }
}
