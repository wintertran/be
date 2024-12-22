using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be.Migrations
{
    /// <inheritdoc />
    public partial class updatebrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { "6", "Other" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Computers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Keyboards");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Mice & Joysticks");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "Tablets & Ipads");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "Cases");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "Covers");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6567));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6569));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6478), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6484), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6486) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6487), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6489) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6519), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6519) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6521), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6523), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6523) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6525), new DateTime(2024, 12, 22, 10, 26, 3, 89, DateTimeKind.Utc).AddTicks(6525) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1",
                column: "Name",
                value: "Shop All");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2",
                column: "Name",
                value: "Computers");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3",
                column: "Name",
                value: "Keyboards");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4",
                column: "Name",
                value: "Mice & Joysticks");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5",
                column: "Name",
                value: "Tablets & Ipads");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6",
                column: "Name",
                value: "Cases");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsAvailable", "Name", "ParentCategoryId" },
                values: new object[] { "7", true, "Covers", null });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4064));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4066));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(3997), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4000) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4002), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4003) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4005), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4006) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4031), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4033), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4034) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4035), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4037), new DateTime(2024, 12, 22, 7, 57, 1, 445, DateTimeKind.Utc).AddTicks(4038) });
        }
    }
}
