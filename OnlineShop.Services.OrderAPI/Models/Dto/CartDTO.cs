﻿namespace OnlineShop.Services.OrderAPI.Models.DTO
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeaderDTO { get; set; }
        public IEnumerable<CartDetailsDTO>? CartDetails { get; set; }
    }
}
