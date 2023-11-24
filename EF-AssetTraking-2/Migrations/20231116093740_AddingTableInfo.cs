using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_AssetTraking_2.Migrations
{
    public partial class AddingTableInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "USA" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Spain" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Sweden" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetType", "Brand", "OfficeId", "Price", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, "Laptop", "MacBook", 1, 5500m, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Laptop", "Asus", 2, 3500m, new DateTime(2021, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Laptop", "Lenovo", 1, 4500m, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Laptop", "MacBook", 3, 6500m, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Laptop", "Asus", 3, 6500m, new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Mobile Phone", "Iphone", 2, 5000m, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Mobile Phone", "Samsung", 3, 3500m, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Mobile Phone", "Nokia", 1, 1000m, new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Mobile Phone", "Iphone", 1, 5500m, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Mobile Phone", "Iphone", 3, 6500m, new DateTime(2021, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_OfficeId",
                table: "Assets",
                column: "OfficeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
