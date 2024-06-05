using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto<IEnumerable<ProductDto>>?> GetAllProductsAsync();
        Task<ResponseDto<ProductDto>?> GetProductByIdAsync(int id);
        Task<ResponseDto<ProductDto>?> CreateProductAsync(ProductDto ProductDto);
        Task<ResponseDto<ProductDto>?> UpdateProductAsync(ProductDto ProductDto);
        Task<ResponseDto<int>?> DeleteProductAsync(int id);
    }
}
