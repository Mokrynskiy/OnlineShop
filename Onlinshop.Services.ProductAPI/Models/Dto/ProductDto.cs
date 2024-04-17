﻿
namespace Onlineshop.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public double Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string ProductCategoryName { get; set; }
    }
}