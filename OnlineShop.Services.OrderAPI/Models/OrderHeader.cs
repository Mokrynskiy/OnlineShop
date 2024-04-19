using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.OrderAPI.Models
{
    public class OrderHeader
    {
        [Key]
        public int OrderHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? DiscountCard { get; set; }
        public decimal Discount { get; set; }
        public decimal CartTotal { get; set; }

        public DateTime OrderTime { get; set; }
        public string? Status { get; set; }
        
        public IEnumerable<OrderDetails> OrderDetails { get; set; }

    }
}
