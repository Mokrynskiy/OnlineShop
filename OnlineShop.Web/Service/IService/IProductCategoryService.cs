using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IProductCategoryService
    {
        Task<ResponseDto<ProductDto>?> GetProductCategoryAsync(string name);
        Task<ResponseDto<IEnumerable<ProductDto>>?> GetAllProductCategorysAsync();
        Task<ResponseDto<ProductDto>?> GetProductCategoryByIdAsync(int id);
        Task<ResponseDto<ProductDto>?> CreateProductCategoryAsync(ProductCategoryDto ProductCategoryDto);
        Task<ResponseDto<ProductDto>?> UpdateProductCategoryAsync(ProductCategoryDto ProductCategoryDto);
        Task<ResponseDto<int>?> DeleteProductCategoryAsync(int id);
    }
}
