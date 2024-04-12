using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.DiscountAPI.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DiscountCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
