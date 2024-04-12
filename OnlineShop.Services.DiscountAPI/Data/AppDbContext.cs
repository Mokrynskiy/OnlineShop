using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.DiscountAPI.Models;

namespace OnlineShop.Services.DiscountAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Discount>().HasData(new Discount
            {
                Id = 1,
                DiscountCode = "10DFF",
                DiscountAmount = 10,
                MinAmount = 20
            });
            modelBuilder.Entity<Discount>().HasData(new Discount
            {
                Id = 2,
                DiscountCode = "20DFF",
                DiscountAmount = 20,
                MinAmount = 40
            });
        }
    }
}
