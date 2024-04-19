namespace OnlineShop.Services.ShoppingCartAPI.Models.DTO
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
