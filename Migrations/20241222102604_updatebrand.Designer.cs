﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using be.Data;

#nullable disable

namespace be.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241222102604_updatebrand")]
    partial class updatebrand
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("be.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("ResetToken")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("be.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<string>("Province")
                        .HasColumnType("text");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ward")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("be.Models.Brand", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Logitech"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Lenovo"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = "4",
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = "5",
                            Name = "Ugreen"
                        },
                        new
                        {
                            Id = "6",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("be.Models.Cart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime?>("AddedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("IsSavedForLater")
                        .HasColumnType("boolean");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("be.Models.CartProduct", b =>
                {
                    b.Property<string>("CartId")
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("be.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParentCategoryId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            IsAvailable = true,
                            Name = "Computers"
                        },
                        new
                        {
                            Id = "2",
                            IsAvailable = true,
                            Name = "Keyboards"
                        },
                        new
                        {
                            Id = "3",
                            IsAvailable = true,
                            Name = "Mice & Joysticks"
                        },
                        new
                        {
                            Id = "4",
                            IsAvailable = true,
                            Name = "Tablets & Ipads"
                        },
                        new
                        {
                            Id = "5",
                            IsAvailable = true,
                            Name = "Cases"
                        },
                        new
                        {
                            Id = "6",
                            IsAvailable = true,
                            Name = "Covers"
                        });
                });

            modelBuilder.Entity("be.Models.Invoice", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("InvoiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("be.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("CartId")
                        .HasColumnType("text");

                    b.Property<string>("CartSnapshot")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("text");

                    b.Property<string>("ShippingAddressId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ShippingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ShippingAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("be.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("BrandId")
                        .HasColumnType("text");

                    b.Property<decimal?>("CartQuantity")
                        .HasColumnType("numeric");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<decimal?>("StockQuantity")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            BrandId = "1",
                            CategoryId = "1",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6478),
                            Description = "High-performance laptop",
                            IsAvailable = true,
                            Name = "Laptop",
                            Price = 7000000m,
                            Sku = "LAP123",
                            StockQuantity = 100m,
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6482)
                        },
                        new
                        {
                            Id = "2",
                            BrandId = "1",
                            CategoryId = "1",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6484),
                            Description = "Latest smartphone model",
                            IsAvailable = true,
                            Name = "Smartphone",
                            Price = 2300000m,
                            Sku = "SMT456",
                            StockQuantity = 200m,
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6486)
                        },
                        new
                        {
                            Id = "3",
                            BrandId = "2",
                            CategoryId = "2",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6487),
                            Description = "Bestselling novel book",
                            IsAvailable = true,
                            Name = "Novel Book",
                            Price = 100000m,
                            Sku = "NBK789",
                            StockQuantity = 300m,
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6489)
                        });
                });

            modelBuilder.Entity("be.Models.ProductImage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");

                    b.HasData(
                        new
                        {
                            Id = "P1-Img1",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6560),
                            ImageUrl = "https://placehold.co/400x400",
                            ProductId = "1"
                        },
                        new
                        {
                            Id = "P1-Img2",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6562),
                            ImageUrl = "https://placehold.co/400x400/gray",
                            ProductId = "1"
                        },
                        new
                        {
                            Id = "P1-Img3",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6563),
                            ImageUrl = "https://placehold.co/400x400/black",
                            ProductId = "1"
                        },
                        new
                        {
                            Id = "P1-Img4",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6564),
                            ImageUrl = "https://placehold.co/400x400/blue",
                            ProductId = "1"
                        },
                        new
                        {
                            Id = "P2-Img1",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6565),
                            ImageUrl = "https://placehold.co/400x400",
                            ProductId = "2"
                        },
                        new
                        {
                            Id = "P2-Img2",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6566),
                            ImageUrl = "https://placehold.co/400x400/gray",
                            ProductId = "2"
                        },
                        new
                        {
                            Id = "P2-Img3",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6567),
                            ImageUrl = "https://placehold.co/400x400/black",
                            ProductId = "2"
                        },
                        new
                        {
                            Id = "P2-Img4",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6568),
                            ImageUrl = "https://placehold.co/400x400/blue",
                            ProductId = "2"
                        },
                        new
                        {
                            Id = "P3-Img1",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6569),
                            ImageUrl = "https://placehold.co/400x400",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "P3-Img2",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6570),
                            ImageUrl = "https://placehold.co/400x400/gray",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "P3-Img3",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6571),
                            ImageUrl = "https://placehold.co/400x400/black",
                            ProductId = "3"
                        },
                        new
                        {
                            Id = "P3-Img4",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6572),
                            ImageUrl = "https://placehold.co/400x400/blue",
                            ProductId = "3"
                        });
                });

            modelBuilder.Entity("be.Models.Rating", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RatingValue")
                        .HasColumnType("integer");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = "R1",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6519),
                            ProductId = "1",
                            RatingValue = 5,
                            Review = "Excellent performance!",
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6519),
                            UserId = "U1"
                        },
                        new
                        {
                            Id = "R2",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6521),
                            ProductId = "1",
                            RatingValue = 4,
                            Review = "Good value for money.",
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6521),
                            UserId = "U2"
                        },
                        new
                        {
                            Id = "R3",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6523),
                            ProductId = "2",
                            RatingValue = 5,
                            Review = "Amazing features!",
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6523),
                            UserId = "U3"
                        },
                        new
                        {
                            Id = "R4",
                            CreatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6525),
                            ProductId = "3",
                            RatingValue = 4,
                            Review = "Engaging and well-written.",
                            UpdatedAt = new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6525),
                            UserId = "U4"
                        });
                });

            modelBuilder.Entity("be.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("be.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ResetToken")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("be.Models.Account", b =>
                {
                    b.HasOne("be.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("be.Models.Address", b =>
                {
                    b.HasOne("be.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("be.Models.Cart", b =>
                {
                    b.HasOne("be.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("be.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("be.Models.CartProduct", b =>
                {
                    b.HasOne("be.Models.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("be.Models.Product", "Product")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("be.Models.Order", b =>
                {
                    b.HasOne("be.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("be.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("be.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Cart");

                    b.Navigation("User");
                });

            modelBuilder.Entity("be.Models.Product", b =>
                {
                    b.HasOne("be.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("be.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("be.Models.ProductImage", b =>
                {
                    b.HasOne("be.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("be.Models.Rating", b =>
                {
                    b.HasOne("be.Models.Product", "Product")
                        .WithMany("Ratings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("be.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("be.Models.Cart", b =>
                {
                    b.Navigation("CartProducts");
                });

            modelBuilder.Entity("be.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("be.Models.Product", b =>
                {
                    b.Navigation("CartProducts");

                    b.Navigation("ProductImages");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("be.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cart");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
