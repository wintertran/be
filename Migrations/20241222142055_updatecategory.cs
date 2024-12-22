using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace be.Migrations
{
    /// <inheritdoc />
    public partial class updatecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "Hardware");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsAvailable", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { "10", true, "Other", null },
                    { "8", true, "Speaker", null },
                    { "9", true, "Monitor", null }
                });

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1074));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1076));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1077));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1078));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P10-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P11-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P12-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P13-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1127));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P14-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1079));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P4-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P5-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P6-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P7-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P8-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P9-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(950), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(952) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(977), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(978) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(979), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(980) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(982), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(983) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(985), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(986) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(988), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(954), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(957), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(958) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(961) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(963), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(966), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(968), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(971), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(972) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(974), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1023), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1023) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R10",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1039), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1040) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R11",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1041), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1042) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R12",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1043), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1044) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R13",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1045), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1045) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R14",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1047), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1047) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1025), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1025) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1027), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1027) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1028), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1029) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1030), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1032), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1034), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R8",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1036), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1038), new DateTime(2024, 12, 22, 14, 20, 55, 424, DateTimeKind.Utc).AddTicks(1038) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7",
                column: "Name",
                value: "Other");

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P1-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P10-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P11-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P12-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7570));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P13-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P14-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img2",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img3",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P2-Img4",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P3-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P4-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P5-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P6-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P7-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7565));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P8-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: "P9-Img1",
                column: "CreatedAt",
                value: new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7369), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7371) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "10",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7397), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7398) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7400), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "12",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7403), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "13",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7406), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "14",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7408), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7409) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7373), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7374) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7378), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7381), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7382) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7384), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7385) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7387), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7388) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7389), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7390) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "8",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7392), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7395), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7396) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R1",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7441), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7442) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R10",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7457), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7457) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R11",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7459), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7459) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R12",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7460), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R13",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7462), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7463) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R14",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7464), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7464) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R2",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7443), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R3",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7445), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R4",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7447), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7447) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R5",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7448), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7449) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R6",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7450), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R7",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7452), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7452) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R8",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7454), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: "R9",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7455), new DateTime(2024, 12, 22, 13, 29, 28, 370, DateTimeKind.Utc).AddTicks(7456) });
        }
    }
}
