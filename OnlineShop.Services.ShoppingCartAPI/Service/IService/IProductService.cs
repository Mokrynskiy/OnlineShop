using OnlineShop.Services.ShoppingCartAPI.Models.DTO;

namespace OnlineShop.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
