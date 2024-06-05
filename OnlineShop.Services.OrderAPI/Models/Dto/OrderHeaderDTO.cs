namespace OnlineShop.Services.OrderAPI.Models.Dto
{
    public class OrderHeaderDto
    {
        public int OrderHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? DiscountCard { get; set; }
        public decimal Discount { get; set; }
        public decimal OrderTotal { get; set; }

        public DateTime OrderTime { get; set; }
        public string? Status { get; set; }

        public IEnumerable<OrderDetailsDto> OrderDetails { get; set; }
    }
}
