using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoesShop.DAL.Entities;

namespace ShoesShop.DAL.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Name).HasColumnType("nvarchar(400)");
            //Base
            builder.Property(p => p.CreatedDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.LastModifiedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnType("nvarchar(50)");
        }
    }
}