using Microsoft.EntityFrameworkCore;
using Onlineshop.Services.ProductAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Кружка",
                Price = 299,
                Description = "Кружка ST градиент",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/3d8/250_273_240cd750bba9870f18aada2478b24840a/mm3ndp9890r7d40bck42bq6b4q0seugp.jpg",
                ProductCategoryName = "Посуда"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Тарелка",
                Price = 159,
                Description = "Тарелка 26 см",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/b48/250_273_240cd750bba9870f18aada2478b24840a/4iihmyj7kflksk5a1gn8ax3vo21yu2z4.jpg",
                ProductCategoryName = "Посуда"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Миска",
                Price = 450,
                Description = "Стеклянная миска",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/3ee/250_273_240cd750bba9870f18aada2478b24840a/3ee3caeebbef1bff678806669d533334.jpg",
                ProductCategoryName = "Посуда"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Стакан",
                Price = 370,
                Description = "Стакан 380мл",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/c48/250_273_240cd750bba9870f18aada2478b24840a/2ujxde7jjrzhnxuywe19736f01ysw1j0.jpg",
                ProductCategoryName = "Посуда"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Банка",
                Price = 630,
                Description = "Банка с бамбуковой крышкой 900мл",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/acd/250_273_240cd750bba9870f18aada2478b24840a/fp2o38xhuvzz8e8wrc1l2fkyx7wj0y0d.jpg",
                ProductCategoryName = "Посуда"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Миска",
                Price = 420,
                Description = "Миска 12х6см",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/5bc/250_273_240cd750bba9870f18aada2478b24840a/wmkaby02mwvg07yo9duc6et4t46ugenh.jpg",
                ProductCategoryName = "Посуда"
            });

        }
    }
}
