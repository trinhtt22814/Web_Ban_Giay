using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Username).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.FullName).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnType("datetime");
            builder.Property(x => x.Address).HasColumnType("nvarchar(400)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("nvarchar(200)");
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(x => x.Gender).HasColumnType("nvarchar(200)");
            builder.Property(x => x.Avatar).HasColumnType("nvarchar(400)");
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
            // Set Foreign Key
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.IDRole);
        }
    }
}