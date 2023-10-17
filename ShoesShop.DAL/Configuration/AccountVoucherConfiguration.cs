using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class AccountVoucherConfiguration : IEntityTypeConfiguration<AccountVoucher>
    {
        public void Configure(EntityTypeBuilder<AccountVoucher> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.IsDeleted).HasColumnType("bit");
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.User).WithMany(x => x.AccountVoucher).HasForeignKey(x => x.IDUser);
            builder.HasOne(x => x.Voucher).WithMany(x => x.AccountVouchers).HasForeignKey(x => x.IDVoucher);
        }
    }
}