using System.ComponentModel.DataAnnotations;


namespace Onlineshop.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range (0, 10000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }                
        public string ProductCategoryName { get; set;}
        

    }
}
