using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.DeliveryAddress).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Username).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.ConfirmationDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Type).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Note).HasColumnType("nvarchar(200)").IsRequired();
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.User).WithMany(x => x.Order).HasForeignKey(x => x.IDUser);
        }
    }
}