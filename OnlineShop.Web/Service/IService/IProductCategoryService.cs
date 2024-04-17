using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IProductCategoryService
    {
        Task<ResponseDto?> GetProductCategoryAsync(string name);
        Task<ResponseDto?> GetAllProductCategorysAsync();
        Task<ResponseDto?> GetProductCategoryByIdAsync(int id);
        Task<ResponseDto?> CreateProductCategoryAsync(ProductCategoryDto ProductCategoryDto);
        Task<ResponseDto?> UpdateProductCategoryAsync(ProductCategoryDto ProductCategoryDto);
        Task<ResponseDto?> DeleteProductCategoryAsync(int id);
    }
}
