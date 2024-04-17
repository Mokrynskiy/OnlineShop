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
                Price = 299,
                Description = "Тарелка 26 см",
                PictureUrl = "https://www.modi.ru/upload/resize_cache/product/b48/250_273_240cd750bba9870f18aada2478b24840a/4iihmyj7kflksk5a1gn8ax3vo21yu2z4.jpg",
                ProductCategoryName = "Посуда"
            });
        }
    }
}
