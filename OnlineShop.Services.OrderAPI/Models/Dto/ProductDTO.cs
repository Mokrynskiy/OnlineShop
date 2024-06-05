namespace OnlineShop.Services.OrderAPI.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
