using LibraryNet.Repository.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore.Mappings
{
    internal class MappingPublishCompany : IEntityTypeConfiguration<PublishCompany>
    {
        public void Configure(EntityTypeBuilder<PublishCompany> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Name)
                   .HasMaxLength(20);
            builder.Property(b => b.Phone)
                   .HasMaxLength(20);
            builder.Property(b => b.WebSite)
                   .HasMaxLength(100);
            builder.HasMany(pc => pc.Books);
        }
    }
}
