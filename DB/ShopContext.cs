using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ShopContext : DbContext

    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<DesiredProduct> DesiredProducts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<DesiredProduct>().ToTable("DesiredProduct");
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<User>()
                .HasMany(u => u.DesiredProducts)
                .WithOne(dp => dp.User)
                .HasForeignKey(dp => dp.UserId);

            modelBuilder.Entity<DesiredProduct>()
                .HasOne(dp => dp.Product)
                .WithMany()
                .HasForeignKey(dp => dp.ProductId);
        }

    }
}
