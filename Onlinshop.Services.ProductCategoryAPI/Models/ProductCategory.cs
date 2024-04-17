﻿using System.ComponentModel.DataAnnotations;

namespace Onlineshop.Services.ProductCategoryAPI.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
