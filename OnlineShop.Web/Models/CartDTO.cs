namespace OnlineShop.Web.Models { 
    public class CartDTO
    {
        public CartHeaderDTO CartHeaderDTO { get; set; }
        public IEnumerable<CartDetailsDTO>? CartDetails { get; set; }
    }
}
