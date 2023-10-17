using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.RoleName).HasColumnType("nvarchar(100)");
            builder.Property(p => p.CreateDate).HasColumnType("datetime");
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
        }
    }
}