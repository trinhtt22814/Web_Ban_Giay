using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.IDUser);
            builder.Property(x => x.Description).HasColumnType("nvarchar(200)");
        }
    }
}