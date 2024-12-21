using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be.Migrations
{
    /// <inheritdoc />
    public partial class stockquality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1001));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "StockQuantity", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(943), 100m, new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(945) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "StockQuantity", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(947), 200m, new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "StockQuantity", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(950), 300m, new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(951) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(971), new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(971) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(973), new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(975), new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(976), new DateTime(2024, 12, 21, 18, 18, 8, 487, DateTimeKind.Utc).AddTicks(977) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "StockQuantity", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(979), null, new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "StockQuantity", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(989), null, new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "StockQuantity", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1049), null, new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1079), new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1080) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1081), new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1084), new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1084) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1085), new DateTime(2024, 12, 21, 18, 9, 32, 370, DateTimeKind.Utc).AddTicks(1086) });
        }
    }
}
