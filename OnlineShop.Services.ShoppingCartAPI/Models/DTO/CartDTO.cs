namespace OnlineShop.Services.ShoppingCartAPI.Models.DTO
{
    public class CartDto
    {
        public CartHeaderDTO CartHeaderDTO { get; set; }
        public IEnumerable<CartDetailsDTO>? CartDetails { get; set; }
    }
}
