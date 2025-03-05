using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4c0f0e32-38ee-47d0-88e4-acbd9062e8da"), "Easy" },
                    { new Guid("5cbb6365-1d33-4365-8e98-0d84bef71cb3"), "Hard" },
                    { new Guid("bb1e5d6f-76d1-4573-9e12-a201e5d576be"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("5258c24f-5731-482d-a30a-551d5736987e"), "GRN", "Gorgan", "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg" },
                    { new Guid("54193e0d-36b0-4763-81aa-98a09b5a2345"), "THN", "Tehran", "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg" },
                    { new Guid("6816a60c-9e51-4218-ae33-41af66a29d2f"), "BJD", "Birjand", null },
                    { new Guid("a3a3a3a3-3a3a-3a3a-3a3a-3a3a3a3a3a3a"), "RAS", "Rasht", "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg" },
                    { new Guid("b3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"), "KRM", "Kerman", null },
                    { new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"), "SHR", "Shiraz", "https://cdn.pixabay.com/photo/2016/11/29/05/45/aerial-1867092_960_720.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4c0f0e32-38ee-47d0-88e4-acbd9062e8da"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5cbb6365-1d33-4365-8e98-0d84bef71cb3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bb1e5d6f-76d1-4573-9e12-a201e5d576be"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5258c24f-5731-482d-a30a-551d5736987e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("54193e0d-36b0-4763-81aa-98a09b5a2345"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6816a60c-9e51-4218-ae33-41af66a29d2f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a3a3a3a3-3a3a-3a3a-3a3a-3a3a3a3a3a3a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f3b3b3b3-1b3b-4b3b-8b3b-3b3b3b3b3b3b"));
        }
    }
}
