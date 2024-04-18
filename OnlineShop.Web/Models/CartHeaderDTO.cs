namespace OnlineShop.Web.Models
{
    public class CartHeaderDTO
    {
        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? DiscountCard { get; set; }
        public decimal Discount { get; set; }
        public decimal CartTotal { get; set; }
    }
}