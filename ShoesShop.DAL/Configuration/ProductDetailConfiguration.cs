using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Description).HasColumnType("nvarchar(200)");
            builder.Property(x => x.DefaultImage).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Gender).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.Category).WithMany(x => x.ProductDetail).HasForeignKey(x => x.IDCategory);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductDetail).HasForeignKey(x => x.IDProduct);
            builder.HasOne(x => x.Brand).WithMany(x => x.ProductDetail).HasForeignKey(x => x.IDBrand);
            builder.HasOne(x => x.Color).WithMany(x => x.ProductDetail).HasForeignKey(x => x.IDColor);
            builder.HasOne(x => x.Material).WithMany(x => x.ProductDetail).HasForeignKey(x => x.IDMaterial);
            builder.HasOne(x => x.Size).WithMany(x => x.ProductDetail).HasForeignKey(x => x.IDSize);
        }
    }
}