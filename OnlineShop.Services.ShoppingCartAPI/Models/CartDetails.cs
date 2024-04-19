﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Services.ShoppingCartAPI.Models.DTO;

namespace OnlineShop.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        [Key]
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }
        public int ProductId {get;set; }
        [NotMapped]
        public ProductDTO Product { get; set; }
        public int Count { get; set; }
    }
}
