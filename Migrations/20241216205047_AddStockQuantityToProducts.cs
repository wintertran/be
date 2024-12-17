using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace be.Migrations
{
    /// <inheritdoc />
    public partial class AddStockQuantityToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variations");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "568e85bc-d883-48d6-838c-4a30a3d0dd9e");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "60d7f2a0-87b9-4fb4-9424-f4552caad3dc");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "df8cbb32-846b-446b-af1c-19af0945f58f");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CartQuantity",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StockQuantity",
                table: "Products",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Accounts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                table: "Accounts",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CartQuantity", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { "01caf0dc-df82-41b8-a2ce-a009a9fbec57", "AuthorName", null, "2", new DateTime(2024, 12, 16, 20, 50, 45, 901, DateTimeKind.Utc).AddTicks(4549), "Bestselling novel book", "https://placehold.co/400x400", true, "Novel Book", 20m, "NBK789", null, new DateTime(2024, 12, 16, 20, 50, 45, 901, DateTimeKind.Utc).AddTicks(4550) },
                    { "56533235-773b-4d8b-a41b-742e92b0d8c0", "BrandB", null, "1", new DateTime(2024, 12, 16, 20, 50, 45, 901, DateTimeKind.Utc).AddTicks(4545), "Latest smartphone model", "https://placehold.co/400x400", true, "Smartphone", 500m, "SMT456", null, new DateTime(2024, 12, 16, 20, 50, 45, 901, DateTimeKind.Utc).AddTicks(4545) },
                    { "ac364bf2-846d-4d17-bf5c-8297cfc36b8e", "BrandA", null, "1", new DateTime(2024, 12, 16, 20, 50, 45, 901, DateTimeKind.Utc).AddTicks(4536), "High-performance laptop", "https://placehold.co/400x400", true, "Laptop", 1000m, "LAP123", null, new DateTime(2024, 12, 16, 20, 50, 45, 901, DateTimeKind.Utc).AddTicks(4541) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Products_ProductId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "01caf0dc-df82-41b8-a2ce-a009a9fbec57");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "56533235-773b-4d8b-a41b-742e92b0d8c0");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "ac364bf2-846d-4d17-bf5c-8297cfc36b8e");

            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CartQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ResetToken",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "UpdatedAt" },
                values: new object[,]
                {
                    { "568e85bc-d883-48d6-838c-4a30a3d0dd9e", "BrandA", "1", new DateTime(2024, 11, 13, 10, 5, 45, 103, DateTimeKind.Utc).AddTicks(4799), "High-performance laptop", "https://placehold.co/400x400", true, "Laptop", 1000m, "LAP123", new DateTime(2024, 11, 13, 10, 5, 45, 103, DateTimeKind.Utc).AddTicks(4802) },
                    { "60d7f2a0-87b9-4fb4-9424-f4552caad3dc", "AuthorName", "2", new DateTime(2024, 11, 13, 10, 5, 45, 103, DateTimeKind.Utc).AddTicks(4809), "Bestselling novel book", "https://placehold.co/400x400", true, "Novel Book", 20m, "NBK789", new DateTime(2024, 11, 13, 10, 5, 45, 103, DateTimeKind.Utc).AddTicks(4810) },
                    { "df8cbb32-846b-446b-af1c-19af0945f58f", "BrandB", "1", new DateTime(2024, 11, 13, 10, 5, 45, 103, DateTimeKind.Utc).AddTicks(4806), "Latest smartphone model", "https://placehold.co/400x400", true, "Smartphone", 500m, "SMT456", new DateTime(2024, 11, 13, 10, 5, 45, 103, DateTimeKind.Utc).AddTicks(4807) }
                });
        }
    }
}
