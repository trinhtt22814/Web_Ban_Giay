using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)").IsRequired();
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.ProductDetail).WithMany(x => x.Images).HasForeignKey(x => x.IDProductDetail);
        }
    }
}