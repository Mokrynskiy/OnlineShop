using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;
using static OnlineShop.Web.Utility.SD;

namespace OnlineShop.Web.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IBaseService _baseService;
        public ProductCategoryService(IBaseService baseService)
        {
            _baseService = baseService;    
        }

        
        public async Task<ResponseDto?> CreateProductCategoryAsync(ProductCategoryDto ProductCategoryDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = ProductCategoryDto,
                Url = SD.ProductCategoryAPIBase + "/api/ProductCategory"
            });
        }

        public async Task<ResponseDto?> DeleteProductCategoryAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ProductCategoryAPIBase + "/api/ProductCategory/" + id
            });
        }

        public async Task<ResponseDto?> GetAllProductCategorysAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductCategoryAPIBase + "/api/ProductCategory"
            });
        }

        public async Task<ResponseDto?> GetProductCategoryAsync(string name)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductCategoryAPIBase + "/api/ProductCategory/GetByName/"+ name
            });
        }

        public async Task<ResponseDto?> GetProductCategoryByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductCategoryAPIBase + "/api/ProductCategory/"+ id
            });
        }

        public async Task<ResponseDto?> UpdateProductCategoryAsync(ProductCategoryDto ProductCategoryDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = ProductCategoryDto,
                Url = SD.ProductCategoryAPIBase + "/api/ProductCategory"
            });
        }
    }
}
