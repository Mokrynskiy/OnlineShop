
using OnlineShop.Services.OrderAPI.Models.DTO;

namespace OnlineShop.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
