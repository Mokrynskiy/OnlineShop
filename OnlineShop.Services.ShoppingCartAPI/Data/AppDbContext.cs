﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.ShoppingCartAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.ShoppingCartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }      
    }
}