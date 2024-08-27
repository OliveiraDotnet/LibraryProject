using LibraryNet.Repository.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryNet.Repository.EFCore.Mappings
{
    public class MappingCoupon : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(b => b.Name)
                   .HasMaxLength(100)
                   .IsRequired(true);
            builder.Property(b => b.Type)
                   .HasColumnType("int");
            builder.Property(b => b.DiscountValue)
                   .HasColumnType("decimal");
        }
    }
}
