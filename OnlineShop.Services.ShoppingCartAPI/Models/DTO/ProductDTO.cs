namespace OnlineShop.Services.ShoppingCartAPI.Models.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
