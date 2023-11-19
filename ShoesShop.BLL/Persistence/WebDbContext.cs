using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoesShop.BLL.Services.Interfaces;
using ShoesShop.DAL.Constants;
using ShoesShop.DAL.Entities;
using ShoesShop.DAL.Entities.Base;

namespace ShoesShop.BLL.Persistence
{
    public class WebDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        private readonly IIdentityService _identityService;
        public WebDbContext(DbContextOptions options, IIdentityService identityService) : base(options)
        {
            _identityService = identityService;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Raiting> Ratings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Status> Status { get; set; }

        public override EntityEntry Entry(object entity) => base.Entry(entity);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-399B81S\SQLEXPRESS;Initial Catalog=WebBanGiay;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables

            modelBuilder.Entity<AppUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<AppRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("ApplicationUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("ApplicationUserRoles")
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("ApplicationUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("ApplicationRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("ApplicationUserTokens").HasKey(x => x.UserId);

            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Color>().ToTable("Colors");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Promotion>().ToTable("Promotions");
            modelBuilder.Entity<Property>().ToTable("Properties");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Raiting>().ToTable("Ratings");
            modelBuilder.Entity<Size>().ToTable("Sizes");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #endregion Tables

            #region Set Infomation Coulumn

            modelBuilder.Entity<AppUser>()
                .Property(x => x.UserName)
                .HasMaxLength(300);
            modelBuilder.Entity<AppUser>()
                .Property(x => x.NormalizedUserName)
                .HasMaxLength(300);
            modelBuilder.Entity<AppUser>()
                .Property(x => x.Email)
                .HasMaxLength(300);
            modelBuilder.Entity<AppUser>()
                .Property(x => x.NormalizedEmail)
                .HasMaxLength(300);

            modelBuilder.Entity<AppUser>()
                .HasIndex(x => new { x.UserName, x.NormalizedUserName, x.Email, x.NormalizedEmail })
                .IsUnique();

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasIndex(x => new { x.UserId, x.RoleId })
                .IsUnique(false);

            #endregion Set Infomation Coulumn
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userChange = string.IsNullOrEmpty(_identityService.GetCurrentUserLogin().Id)
                ? AppConst.Author
                : _identityService.GetCurrentUserLogin().Id;
            var dateTimeChange = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries<Audit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = userChange;
                        entry.Entity.CreatedAt = dateTimeChange;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = userChange;
                        entry.Entity.UpdatedAt = dateTimeChange;
                        break;

                    case EntityState.Detached:
                        break;

                    case EntityState.Unchanged:
                        break;

                    case EntityState.Deleted:
                        entry.Entity.UpdatedBy = userChange;
                        entry.Entity.UpdatedAt = dateTimeChange;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}