namespace OnlineShop.Web.Models;

public class CartDto
{
    public CartHeaderDTO CartHeaderDTO { get; set; }
    public IEnumerable<CartDetailsDTO>? CartDetails { get; set; }
}
