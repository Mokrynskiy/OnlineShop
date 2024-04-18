using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Onlineshop.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class ProductAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PictureUrl = table.Column<string>(type: "text", nullable: false),
                    ProductCategoryName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "PictureUrl", "Price", "ProductCategoryName" },
                values: new object[,]
                {
                    { 1, "Кружка ST градиент", "Кружка", "https://www.modi.ru/upload/resize_cache/product/3d8/250_273_240cd750bba9870f18aada2478b24840a/mm3ndp9890r7d40bck42bq6b4q0seugp.jpg", 299.0, "Посуда" },
                    { 2, "Тарелка 26 см", "Тарелка", "https://www.modi.ru/upload/resize_cache/product/b48/250_273_240cd750bba9870f18aada2478b24840a/4iihmyj7kflksk5a1gn8ax3vo21yu2z4.jpg", 299.0, "Посуда" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
