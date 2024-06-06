using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IProductCategoryService
    {
        Task<ResponseDto<ProductDto>?> GetProductCategoryAsync(string name);
        Task<ResponseDto<IEnumerable<ProductDto>>?> GetAllProductCategorysAsync();
        Task<ResponseDto<ProductCategoryDto>?> GetProductCategoryByIdAsync(int id);
        Task<ResponseDto<ProductDto>?> CreateProductCategoryAsync(ProductCategoryDto ProductCategoryDto);
        Task<ResponseDto<ProductCategoryDto>?> UpdateProductCategoryAsync(ProductCategoryDto ProductCategoryDto);
        Task<ResponseDto<int>?> DeleteProductCategoryAsync(int id);
    }
}
