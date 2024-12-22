using be.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<District> Districts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Seed Provinces
            //var provincesJson = File.ReadAllText("Data/Seed/Province.json");
            //var provinces = JsonConvert.DeserializeObject<List<Province>>(provincesJson);
            //modelBuilder.Entity<Province>().HasData(Provinces);

            //// Seed Districts
            //var districtsJson = File.ReadAllText("Data/Seed/District.json");
            //var districts = JsonConvert.DeserializeObject<List<District>>(districtsJson);
            //modelBuilder.Entity<District>().HasData(Districts);

            //// Seed Wards
            //var wardsJson = File.ReadAllText("Data/Seed/Ward.json");
            //var wards = JsonConvert.DeserializeObject<List<Ward>>(wardsJson);
            //modelBuilder.Entity<Ward>().HasData(Wards);
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
                new Category { Id = "1", Name = "Computers", IsAvailable = true },
                new Category { Id = "2", Name = "Keyboards", IsAvailable = true },
                new Category { Id = "3", Name = "Mice & Joysticks", IsAvailable = true },
                new Category { Id = "4", Name = "Tablets & Ipads", IsAvailable = true },
                new Category { Id = "5", Name = "Cases", IsAvailable = true },
                new Category { Id = "6", Name = "Covers", IsAvailable = true },
                new Category { Id = "7", Name = "Hardware", IsAvailable = true },
                new Category { Id = "8", Name = "Speaker", IsAvailable = true },
                new Category { Id = "9", Name = "Monitor", IsAvailable = true },
                new Category { Id = "10", Name = "Other", IsAvailable = true }
            );
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = "1",
                    ImgUrl = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAllBMVEX///8AAAAAuP0Atv0AtP3w8PDHx8fi4uIzMzOHh4eOjo7i9v8sLCzAwMD09PQxwP1JSUlYWFjW1tYDu/3o6Oja2trNzc3Dw8NoaGiLi4uV2/560/5vb2+0tLQcHBwTExNOTk4jIyN8fHw9PT3z/P/V8f+np6eenp5gYGCvr69/f3++6f6s4v6H1/1cy/3G7P9CxP1mzf3UBWDZAAAFb0lEQVR4nO2a6XaiShRGQSZxQFBxSCQ4a4ZOJ+//cpcaqQLFIdDelfXtH60eq8LZ1IxtGAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIDt7v3j49FJNMfuz8CybXv06Dya4mNgWy3C4NGZNMP7yG5xajQMJhnOLRVmvUVwx4WSjHFliU/pV6uhZ2ZMb6jwkpVPb1d0yHX6FQV2I6vVnKF7ffk+KW/us3cT13Xjq+tdMvyrNOBjDffUcG6wxny7ut4Fw50u+EjDsSkqtLNX/+p61YZdSxe0HmhoJFn5A3lTp+FI1bPtwefzDRld4GZDI4jZPFOj4bPShPbX+/aWdC6iGwZDd+IVi2RBtxRkhp38Y3xi3gm8WFSUhtkViouGMgit0d+7NCpQDZOQDjLTV1NINjS2igjh2JhF0XJveGGUZtFeFNK1NF6wmrOhondo09gykYauw8qtEi2Hr7wBv+v2Uw3HLCHKQX7dMzU8Y0Wn0lhGyN14ywvI2bWfx1YxN/RlKFJSyJvQrnH4lQ09zWTNvh2aBTyjRzunZhipJY6s5kGrNmGG5QsQvsUotD713J5sq4jdvdswKGRAW7GYFvEpG67paxotWYCOzVe92qb8p/L+nE8zhSnmqbCGkFa+33DGshsbgRuKtuGNkwfJbo0ZBjHtv2sv5u08zb0ccb/SvecMSc9sy5s1jx2PNe9CZPAuOqn1VMitVkP6kvKJz+fdiDZUyqcdOtYSYWiwuXQubgMvNDVZsENel/wKaTsQhmy5YPdEZJAvFcXcajXc86ZkhCyDTim4KRiS9VD2TEPosh2dKbbnY/KGGvIxaizUrweiCUvTTK2GpJO+yCBtipg6tWWwz3pg0ZA2yMJnzOlYdBzNmkJDr/zDq2ook39v1DA01eltzHqUWQ4OS4ZJcQrJCg3zHqkZilBfMdxaZ5Ov1ZAs6/lBwWFjzjTVfRk1nFxj6E7Iv/qh86xhV040pc1arYZRPjMYvOe5dDRFetArGdJsN6HCZkL/6P5Gw+Jaoa6HNRh22CDjzNmnmRZcs0mkaOiVxxybfcIbDcttqDD6sSHtVzMeo6vEhndAEaQljmfmUrFaGFPWqyPWzRmdpMowH4e7Rg1p4uYskNcn+bF1mwXZcJucMKSrZ0q3KIHPRzO9HWzqDBbU7KyhTN6qegpcgyHLyZx1fHaW2JAv9zLINuBkPSsZ8v1eOO+wfRFtRbYb6r3xWL/CUJwsirvSug0LW2U+/GZa7CU4ZShujlYqSLXYssLwj+ymFQOxDkM22XDE/k1TbFPrsiHbIAj4uHXUY9eiqpfKp2zlTU19hmzpijcio3n+ff9FBPmZMRViyrM2Rx4Qj/mRQd6xNrmBmmGiGspNTdVc8wPDYOq6U7EixJ1juFwk+vPeyTwKl2t5KiePSWkLxxn5wwD34PuHvl4zWS/DqMOds9JD8XVA6spi+db7/BO2HxhW8eb7b/nzhmDt++thRfF7ydd86+tcmYYMabeTn2I5YuvmUzaiNTgz27TuP+NXwY9CHDquqn9buZOu+sD79Kr4zPmu90njXp116Ma7XVn+bp4URbv1VLW5qRdHmUM9OqfuL9S4l4F6irDs1qCBp4onoTtwc9V53R/pu15TF9q2dOr83aIauUIyTjz5roluQfGfGQaaYhNLhWDXsh5iqO7ljvf8tn0920FDvwFfxDlEKzMN5831UMFzM7/j/5/oftnW7zbMzhlfNpP8tYbZcPz4Hv3m/xPF2O7+1v47KQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADgTv4DmsFJm/EjO60AAAAASUVORK5CYII=",
                    Name = "Logitech",
                },
                new Brand
                {
                    Id = "2",
                    ImgUrl = "data:image/png;base64,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",
                    Name = "Lenovo",
                },
                new Brand
                {
                    Id = "3",
                    ImgUrl = "data:image/png;base64,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",
                    Name = "Microsoft",
                },
                new Brand
                {
                    Id = "4",
                    ImgUrl = "data:image/png;base64,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",
                    Name = "Samsung",
                },
                new Brand
                {
                    Id = "5",
                    ImgUrl = "data:image/png;base64,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",
                    Name = "Ugreen",
                },
                new Brand
                {
                    Id = "6",
                    ImgUrl = "data:image/png;base64,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",
                    Name = "Other",
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
                        Id = "3",
                        Name = "POP Mouse",
                        CategoryId = "3",
                        Price = 849000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 50,
                        Description = "Wireless POP Mouse",
                        Sku = "POP123",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "4",
                        Name = "ERGO M575S",
                        CategoryId = "3",
                        Price = 1800000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 40,
                        Description = "Ergonomic Wireless Trackball",
                        Sku = "ERGOM575S",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "5",
                        Name = "MX Ergo S",
                        CategoryId = "3",
                        Price = 1329000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 35,
                        Description = "Precision trackball mouse",
                        Sku = "MXERGO",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "6",
                        Name = "MX Anywhere 3S for Mac",
                        CategoryId = "3",
                        Price = 1500000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 60,
                        Description = "Compact wireless mouse for Mac",
                        Sku = "MXA3SMAC",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "7",
                        Name = "MX Master 3S",
                        CategoryId = "3",
                        Price = 3299000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 45,
                        Description = "High-performance wireless mouse",
                        Sku = "MXMASTER3S",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "8",
                        Name = "MX Master 3S For Mac",
                        CategoryId = "3",
                        Price = 1200000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 50,
                        Description = "High-precision mouse for Mac",
                        Sku = "MXM3SMAC",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "9",
                        Name = "MX Anywhere 3S",
                        CategoryId = "3",
                        Price = 3299000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 70,
                        Description = "Portable wireless mouse",
                        Sku = "MXA3S",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "10",
                        Name = "LIFT",
                        CategoryId = "3",
                        Price = 2500000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 80,
                        Description = "Ergonomic vertical mouse",
                        Sku = "LIFT123",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "11",
                        Name = "Pebble Mouse 2 M350s",
                        CategoryId = "3",
                        Price = 2139990,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 75,
                        Description = "Sleek and silent mouse",
                        Sku = "PEBBLEM2",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "12",
                        Name = "Signature M650",
                        CategoryId = "3",
                        Price = 1700000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 65,
                        Description = "Wireless mouse for everyday use",
                        Sku = "SIGM650",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "13",
                        Name = "M720 Triathlon",
                        CategoryId = "3",
                        Price = 1599000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 85,
                        Description = "Multi-device wireless mouse",
                        Sku = "M720TRI",
                        BrandId = "1",
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Product
                    {
                        Id = "14",
                        Name = "M331 SILENT PLUS",
                        CategoryId = "3",
                        Price = 2200000,
                        IsAvailable = true,
                        CreatedAt = DateTime.UtcNow,
                        StockQuantity = 90,
                        Description = "Silent wireless mouse",
                        Sku = "M331SP",
                        BrandId = "1",
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
                    ProductId = "3",
                    RatingValue = 5,
                    Review = "Stylish and compact!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R5",
                    UserId = "U5",
                    ProductId = "4",
                    RatingValue = 4,
                    Review = "Great ergonomic design.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R6",
                    UserId = "U6",
                    ProductId = "5",
                    RatingValue = 4,
                    Review = "Smooth and precise!",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R7",
                    UserId = "U7",
                    ProductId = "7",
                    RatingValue = 4,
                    Review = "Amazing precision and feel.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R8",
                    UserId = "U8",
                    ProductId = "8",
                    RatingValue = 5,
                    Review = "Great for professional use.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R9",
                    UserId = "U9",
                    ProductId = "9",
                    RatingValue = 4,
                    Review = "Portable and reliable.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R10",
                    UserId = "U10",
                    ProductId = "10",
                    RatingValue = 5,
                    Review = "Ergonomic design, very comfortable.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Rating
                {
                    Id = "R11",
                    UserId = "U11",
                    ProductId = "11",
                    RatingValue = 5,
                    Review = "Silent and sleek mouse.",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
    new Rating
    {
        Id = "R12",
        UserId = "U12",
        ProductId = "12",
        RatingValue = 5,
        Review = "Perfect for work and everyday use.",
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    },
    new Rating
    {
        Id = "R13",
        UserId = "U13",
        ProductId = "13",
        RatingValue = 4,
        Review = "Good value for multi-device users.",
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    },
    new Rating
    {
        Id = "R14",
        UserId = "U14",
        ProductId = "14",
        RatingValue = 4,
        Review = "Silent clicks make it great for quiet spaces.",
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
                new ProductImage
                {
                    Id = "P3-Img1",
                    ProductId = "3",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/pop-mouse-gallery-off-white-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P4-Img1",
                    ProductId = "4",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/pop-mouse-gallery-rose-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P5-Img1",
                    ProductId = "5",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/pop-mouse-gallery-graphite-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P6-Img1",
                    ProductId = "6",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/wave-2/pop-mouse-gallery-mist-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P7-Img1",
                    ProductId = "7",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/pop-mouse-gallery-blast-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P8-Img1",
                    ProductId = "8",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/pop-mouse-gallery-heartbreak-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P9-Img1",
                    ProductId = "9",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/2024-update/pop-mouse-gallery-lilac-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P10-Img1",
                    ProductId = "10",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/wave-2/pop-mouse-gallery-cosmo-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P11-Img1",
                    ProductId = "11",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/pop-wireless-mouse/gallery/pop-mouse-gallery-daydream-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P12-Img1",
                    ProductId = "12",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/m575s-ergo-wireless-trackball/gallery/ergo-m575s-m575sp-graphite-blue-ball-gallery-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P13-Img1",
                    ProductId = "13",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/mx-ergo-s-wireless-trackball-mouse/gallery/mx-ergo-s-graphite-gallery-1.png?v=1",
                    CreatedAt = DateTime.UtcNow
                },
                new ProductImage
                {
                    Id = "P14-Img1",
                    ProductId = "14",
                    ImageUrl = "https://resource.logitech.com/w_386,ar_1.0,c_limit,f_auto,q_auto,dpr_2.0/d_transparent.gif/content/dam/logitech/en/products/mice/mx-anywhere-3s-for-mac/buy/gallery/mx-anywhere-3s-mac-space-grey-gallery-01.png?v=1",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
