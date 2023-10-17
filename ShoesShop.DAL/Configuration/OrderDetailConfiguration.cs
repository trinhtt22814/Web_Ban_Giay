using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            // Set Foreign Key
            builder.HasOne(x => x.ProductDetail).WithMany(x => x.OrderDetail).HasForeignKey(x => x.IDProductDetail);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetail).HasForeignKey(x => x.IDOrder);
        }
    }
}