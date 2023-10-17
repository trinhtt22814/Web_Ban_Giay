using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(x => x.ID);
            // Set Foreign Key
            builder.HasOne(x => x.Cart).WithMany(x => x.CartDetail).HasForeignKey(x => x.IDUser);
            builder.HasOne(x => x.ProductDetail).WithMany(x => x.CartDetails).HasForeignKey(x => x.IDProductDetail);
        }
    }
}