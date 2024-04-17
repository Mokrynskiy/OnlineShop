namespace OnlineShop.Services.ShoppingCartAPI.Models.Dto
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string DiscountCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
