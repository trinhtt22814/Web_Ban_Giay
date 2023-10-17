using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class VoucherDetailConfiguration : IEntityTypeConfiguration<VoucherDetail>
    {
        public void Configure(EntityTypeBuilder<VoucherDetail> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.BeforePrice).IsRequired();
            builder.Property(x => x.AfterPrice).IsRequired();
            builder.Property(x => x.DiscountPrice).IsRequired();
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.Order).WithMany(x => x.VoucherDetail).HasForeignKey(x => x.IDOrder);
            builder.HasOne(x => x.Voucher).WithMany(x => x.VoucherDetail).HasForeignKey(x => x.IDVoucher);
        }
    }
}