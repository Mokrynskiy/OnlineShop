using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Services.DiscountAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiscountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DiscountAmount", "DiscountCode", "MinAmount" },
                values: new object[,]
                {
                    { 1, 10.0, "10DFF", 20 },
                    { 2, 20.0, "20DFF", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
