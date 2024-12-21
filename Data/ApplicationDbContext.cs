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

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
                   .HasKey(a => a.Username); // Username làm khóa chính

            modelBuilder.Entity<User>()
                        .HasKey(u => u.Id); // Id làm khóa chính
                                            // Cấu hình bảng liên kết CartProduct

            modelBuilder.Entity<User>()
                    .HasOne(u => u.Cart)
                    .WithOne(c => c.User)
                    .HasForeignKey<Cart>(c => c.UserId) // Cart.UserId is the foreign key
                    .OnDelete(DeleteBehavior.Cascade);
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

            // Quan hệ 1-N giữa User và Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Xóa Order không xóa User

            // Quan hệ 1-1 giữa Address và Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany() // Không có quan hệ ngược từ Address tới Order
                .HasForeignKey(o => o.ShippingAddressId)
                .OnDelete(DeleteBehavior.Restrict); // Xóa Address không xóa Order

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull); // Nếu xóa Brand, không xóa Product




            // Seed
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = "1", Name = "Shop All", IsAvailable = true },
                new Category { Id = "2", Name = "Computers", IsAvailable = true },
                new Category { Id = "3", Name = "Keyboards", IsAvailable = true },
                new Category { Id = "4", Name = "Mice & Joysticks", IsAvailable = true },
                new Category { Id = "5", Name = "Tablets & Ipads", IsAvailable = true },
                new Category { Id = "6", Name = "Cases", IsAvailable = true },
                new Category { Id = "7", Name = "Covers", IsAvailable = true }
            );
            modelBuilder.Entity<Brand>().HasData(
    new Brand
    {
        Id = "1",
        Name = "Logitech",
    },
    new Brand
    {
        Id = "2",
        Name = "Lenovo",
    },
    new Brand
    {
        Id = "3",
        Name = "Microsoft",
    },
    new Brand
    {
        Id = "4",
        Name = "Samsung",
    },
    new Brand
    {
        Id = "5",
        Name = "Ugreen",
    }
);


            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "1", // Static ID for consistency
                    Name = "Laptop",
                    CategoryId = "1",
                    Price = 7000000,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    StockQuantity = 100,
                    Description = "High-performance laptop",
                    Sku = "LAP123",
                    BrandId = "1",
                    UpdatedAt = DateTime.UtcNow,
                },
                new Product
                {
                    Id = "2", // Static ID for consistency
                    Name = "Smartphone",
                    CategoryId = "1",
                    Price = 2300000,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    StockQuantity = 200,
                    Description = "Latest smartphone model",
                    Sku = "SMT456",
                    BrandId = "1",
                    UpdatedAt = DateTime.UtcNow
                },
                new Product
                {
                    Id = "3", // Static ID for consistency
                    Name = "Novel Book",
                    CategoryId = "2",
                    Price = 100000,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    StockQuantity = 300,
                    Description = "Bestselling novel book",
                    Sku = "NBK789",
                    BrandId = "2",
                    UpdatedAt = DateTime.UtcNow
                }
            );

            // Seed Ratings
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = "R1",
                    UserId = "U1",
                    ProductId = "1", // Matches static Product ID
                    RatingValue = 5,
                    Review = "Excellent performance!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R2",
                    UserId = "U2",
                    ProductId = "1", // Matches static Product ID
                    RatingValue = 4,
                    Review = "Good value for money.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R3",
                    UserId = "U3",
                    ProductId = "2", // Matches static Product ID
                    RatingValue = 5,
                    Review = "Amazing features!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R4",
                    UserId = "U4",
                    ProductId = "3", // Matches static Product ID
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
                    Id = "P1-Img1",
                    ProductId = "1", // Matches static Product ID
                    ImageUrl = "https://placehold.co/400x400",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P1-Img2",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400/gray",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P1-Img3",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400/black",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P1-Img4",
                    ProductId = "1",
                    ImageUrl = "https://placehold.co/400x400/blue",
                    CreatedAt = DateTime.UtcNow
                },

                // Images for Smartphone
                new ProductImage
                {
                    Id = "P2-Img1",
                    ProductId = "2", // Matches static Product ID
                    ImageUrl = "https://placehold.co/400x400",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P2-Img2",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400/gray",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P2-Img3",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400/black",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P2-Img4",
                    ProductId = "2",
                    ImageUrl = "https://placehold.co/400x400/blue",
                    CreatedAt = DateTime.UtcNow
                },

                // Images for Novel Book
                new ProductImage
                {
                    Id = "P3-Img1",
                    ProductId = "3", // Matches static Product ID
                    ImageUrl = "https://placehold.co/400x400",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P3-Img2",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400/gray",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P3-Img3",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400/black",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P3-Img4",
                    ProductId = "3",
                    ImageUrl = "https://placehold.co/400x400/blue",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
