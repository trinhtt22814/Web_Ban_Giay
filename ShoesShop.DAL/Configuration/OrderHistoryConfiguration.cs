using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ActionDescription).HasColumnType("nvarchar(200)");
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.Order).WithMany(x => x.OrderHistory).HasForeignKey(x => x.IdOrder);
        }
    }
}