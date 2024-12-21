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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ShippingAddressId = table.Column<string>(type: "text", nullable: false),
                    CartId = table.Column<string>(type: "text", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ShippingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                    Brand = table.Column<string>(type: "text", nullable: true),
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
                columns: new[] { "Id", "Brand", "CartQuantity", "CategoryId", "CreatedAt", "Description", "IsAvailable", "Name", "Price", "Sku", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { "1", "BrandA", null, "1", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(979), "High-performance laptop", true, "Laptop", 7000000m, "LAP123", null, new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(983) },
                    { "2", "BrandB", null, "1", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(989), "Latest smartphone model", true, "Smartphone", 2300000m, "SMT456", null, new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(989) },
                    { "3", "AuthorName", null, "2", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1049), "Bestselling novel book", true, "Novel Book", 100000m, "NBK789", null, new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1050) }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { "P1-Img1", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1113), "https://placehold.co/400x400", "1" },
                    { "P1-Img2", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1115), "https://placehold.co/400x400/gray", "1" },
                    { "P1-Img3", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1116), "https://placehold.co/400x400/black", "1" },
                    { "P1-Img4", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1118), "https://placehold.co/400x400/blue", "1" },
                    { "P2-Img1", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1119), "https://placehold.co/400x400", "2" },
                    { "P2-Img2", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1121), "https://placehold.co/400x400/gray", "2" },
                    { "P2-Img3", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1122), "https://placehold.co/400x400/black", "2" },
                    { "P2-Img4", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1123), "https://placehold.co/400x400/blue", "2" },
                    { "P3-Img1", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1125), "https://placehold.co/400x400", "3" },
                    { "P3-Img2", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1126), "https://placehold.co/400x400/gray", "3" },
                    { "P3-Img3", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1127), "https://placehold.co/400x400/black", "3" },
                    { "P3-Img4", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1128), "https://placehold.co/400x400/blue", "3" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "CreatedAt", "ProductId", "RatingValue", "Review", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { "R1", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1079), "1", 5, "Excellent performance!", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1080), "U1" },
                    { "R2", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1081), "1", 4, "Good value for money.", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1082), "U2" },
                    { "R3", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1084), "2", 5, "Amazing features!", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1084), "U3" },
                    { "R4", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1085), "3", 4, "Engaging and well-written.", new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1086), "U4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductId",
                table: "CartProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

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
                name: "Addresses");

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
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
