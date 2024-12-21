using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace be.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ParentCategoryId = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PaymentStatus = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<string>(type: "text", nullable: true),
                    ResetToken = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    BrandId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: true),
                    StockQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    CartQuantity = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Username = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    ResetToken = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: true),
                    Province = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Ward = table.Column<string>(type: "text", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: true),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    IsSavedForLater = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    RatingValue = table.Column<int>(type: "integer", nullable: true),
                    Review = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ShippingAddressId = table.Column<string>(type: "text", nullable: false),
                    CartSnapshot = table.Column<string>(type: "text", nullable: true),
                    CartId = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Logitech" },
                    { "2", "Lenovo" },
                    { "3", "Microsoft" },
                    { "4", "Samsung" },
                    { "5", "Ugreen" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsAvailable", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { "1", true, "Shop All", null },
                    { "2", true, "Computers", null },
                    { "3", true, "Keyboards", null },
                    { "4", true, "Mice & Joysticks", null },
                    { "5", true, "Tablets & Ipads", null },
                    { "6", true, "Cases", null },
                    { "7", true, "Covers", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CartQuantity", "CategoryId", "CreatedAt", "Description", "IsAvailable", "Name", "Price", "Sku", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", "1", null, "1", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4753), "High-performance laptop", true, "Laptop", 7000000m, "LAP123", 100m, new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4756) },
                    { "2", "1", null, "1", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4757), "Latest smartphone model", true, "Smartphone", 2300000m, "SMT456", 200m, new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4758) },
                    { "3", "2", null, "2", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4760), "Bestselling novel book", true, "Novel Book", 100000m, "NBK789", 300m, new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4761) }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "P1-Img1", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4813), "https://placehold.co/400x400", "1" },
                    { "P1-Img2", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4814), "https://placehold.co/400x400/gray", "1" },
                    { "P1-Img3", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4815), "https://placehold.co/400x400/black", "1" },
                    { "P1-Img4", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4816), "https://placehold.co/400x400/blue", "1" },
                    { "P2-Img1", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4817), "https://placehold.co/400x400", "2" },
                    { "P2-Img2", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4818), "https://placehold.co/400x400/gray", "2" },
                    { "P2-Img3", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4819), "https://placehold.co/400x400/black", "2" },
                    { "P2-Img4", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4820), "https://placehold.co/400x400/blue", "2" },
                    { "P3-Img1", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4821), "https://placehold.co/400x400", "3" },
                    { "P3-Img2", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4822), "https://placehold.co/400x400/gray", "3" },
                    { "P3-Img3", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4823), "https://placehold.co/400x400/black", "3" },
                    { "P3-Img4", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4824), "https://placehold.co/400x400/blue", "3" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CreatedAt", "ProductId", "RatingValue", "Review", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { "R1", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4786), "1", 5, "Excellent performance!", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4787), "U1" },
                    { "R2", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4788), "1", 4, "Good value for money.", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4789), "U2" },
                    { "R3", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4790), "2", 5, "Amazing features!", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4791), "U3" },
                    { "R4", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4792), "3", 4, "Engaging and well-written.", new DateTime(2024, 12, 21, 21, 35, 3, 337, DateTimeKind.Utc).AddTicks(4792), "U4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
