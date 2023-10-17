using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Code).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.StartDate).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.EndDate).HasColumnType("datetime").IsRequired();
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
        }
    }
}