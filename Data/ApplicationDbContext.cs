using be.Models;
using Microsoft.EntityFrameworkCore;

namespace be.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed dữ liệu cho Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = "1", Name = "Electronics", IsAvailable = true },
                new Category { Id = "2", Name = "Books", IsAvailable = true }
            );
            modelBuilder.Entity<Account>()
                   .HasKey(a => a.Username); // Username làm khóa chính

            modelBuilder.Entity<User>()
                        .HasKey(u => u.Id); // Id làm khóa chính
                                            // Cấu hình bảng liên kết CartProduct
            modelBuilder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartId, cp.ProductId });

            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.CartId);

            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(cp => cp.ProductId);

            // Seed dữ liệu cho Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Laptop",
                    CategoryId = "1",
                    Price = 1000,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    Description = "High-performance laptop",
                    ImageUrl = "https://placehold.co/400x400",
                    Sku = "LAP123",
                    Brand = "BrandA",
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Smartphone",
                    CategoryId = "1",
                    Price = 500,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    Description = "Latest smartphone model",
                    ImageUrl = "https://placehold.co/400x400",
                    Sku = "SMT456",
                    Brand = "BrandB",
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Novel Book",
                    CategoryId = "2",
                    Price = 20,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    Description = "Bestselling novel book",
                    ImageUrl = "https://placehold.co/400x400",
                    Sku = "NBK789",
                    Brand = "AuthorName",
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
