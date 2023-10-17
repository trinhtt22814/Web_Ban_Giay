using Microsoft.EntityFrameworkCore;
using ShoesShop.DAL.Entities;
using System.Reflection;

namespace ShoesShop.DAL.ApplicationDbContext
{
    public class WebDbContext : DbContext
    {
        public WebDbContext()
        {
        }

        public WebDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountVoucher> AccountVouchers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherDetail> VoucherDetails { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-399B81S\SQLEXPRESS;Initial Catalog=WebBanGiay;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>().HasOne(x => x.Cart).WithOne(x => x.User).HasForeignKey<Cart>(c => c.IDUser);
        }
    }
}