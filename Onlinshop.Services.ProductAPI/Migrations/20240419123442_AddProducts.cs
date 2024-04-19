using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Onlineshop.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "ProductCategoryName" },
                values: new object[,]
                {
                    { 3, "Стеклянная миска", "Миска", "https://www.modi.ru/upload/resize_cache/product/3ee/250_273_240cd750bba9870f18aada2478b24840a/3ee3caeebbef1bff678806669d533334.jpg", 450.0, "Посуда" },
                    { 4, "Стакан 380мл", "Стакан", "https://www.modi.ru/upload/resize_cache/product/c48/250_273_240cd750bba9870f18aada2478b24840a/2ujxde7jjrzhnxuywe19736f01ysw1j0.jpg", 370.0, "Посуда" },
                    { 5, "Банка с бамбуковой крышкой 900мл", "Банка", "https://www.modi.ru/upload/resize_cache/product/acd/250_273_240cd750bba9870f18aada2478b24840a/fp2o38xhuvzz8e8wrc1l2fkyx7wj0y0d.jpg", 299.0, "Посуда" },
                    { 6, "Миска 12х6см", "Миска", "https://www.modi.ru/upload/resize_cache/product/5bc/250_273_240cd750bba9870f18aada2478b24840a/wmkaby02mwvg07yo9duc6et4t46ugenh.jpg", 299.0, "Посуда" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
