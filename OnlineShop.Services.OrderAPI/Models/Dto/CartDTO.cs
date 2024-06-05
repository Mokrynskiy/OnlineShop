namespace OnlineShop.Services.OrderAPI.Models.DTO
{
    public class CartDto
    {
        public CartHeaderDto CartHeaderDTO { get; set; }
        public IEnumerable<CartDetailsDto>? CartDetails { get; set; }
    }
}
