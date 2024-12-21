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

            modelBuilder.Entity<ProductImage>()
            .HasOne(pi => pi.Product)
            .WithMany(p => p.ProductImages)
            .HasForeignKey(pi => pi.ProductId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if the product is deleted

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
                    Sku = "LAP123",
                    Brand = "BrandA",
                    UpdatedAt = DateTime.UtcNow,
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
                    Sku = "NBK789",
                    Brand = "AuthorName",
                    UpdatedAt = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = "101",
                    UserId = "U1",
                    ProductId = "1", // Reference Laptop
                    RatingValue = 5,
                    Review = "Excellent performance!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "102",
                    UserId = "U2",
                    ProductId = "1", // Reference Laptop
                    RatingValue = 4,
                    Review = "Good value for money.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "103",
                    UserId = "U3",
                    ProductId = "2", // Reference Smartphone
                    RatingValue = 5,
                    Review = "Amazing features!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "104",
                    UserId = "U4",
                    ProductId = "3", // Reference Novel Book
                    RatingValue = 4,
                    Review = "Engaging and well-written.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
            // Seed ProductImages
            modelBuilder.Entity<ProductImage>().HasData(
                // Images for Laptop
                new ProductImage
                {
                    Id = "101",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "102",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400/gray",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "103",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400/black",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "104",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400/blue",
                    CreatedAt = DateTime.UtcNow
                },

                // Images for Smartphone
                new ProductImage
                {
                    Id = "201",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "202",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400/gray",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "203",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400/black",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "204",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400/blue",
                    CreatedAt = DateTime.UtcNow
                },

                // Images for Novel Book
                new ProductImage
                {
                    Id = "301",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "302",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400/gray",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "303",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400/black",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "304",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400/blue",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
