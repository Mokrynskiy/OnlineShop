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

        
        public async Task<ResponseDto<ProductDto>?> CreateProductCategoryAsync(ProductCategoryDto ProductCategoryDto)
        {
            return await _baseService.SendAsync<ResponseDto<ProductDto>>(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = ProductCategoryDto,
                Url = SD.ProductCategoryAPIBase + "/api/productCategory"
            });
        }

        public async Task<ResponseDto<int>?> DeleteProductCategoryAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto<int>>(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ProductCategoryAPIBase + "/api/productCategory/" + id
            });
        }

        public async Task<ResponseDto<IEnumerable<ProductDto>>?> GetAllProductCategorysAsync()
        {
            return await _baseService.SendAsync<ResponseDto<IEnumerable<ProductDto>>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductCategoryAPIBase + "/api/productCategory"
            });
        }

        public async Task<ResponseDto<ProductDto>?> GetProductCategoryAsync(string name)
        {
            return await _baseService.SendAsync<ResponseDto<ProductDto>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductCategoryAPIBase + "/api/productCategory/GetByName/"+ name
            });
        }

        public async Task<ResponseDto<ProductCategoryDto>?> GetProductCategoryByIdAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto<ProductCategoryDto>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductCategoryAPIBase + "/api/productCategory/"+ id
            });
        }

        public async Task<ResponseDto<ProductCategoryDto>?> UpdateProductCategoryAsync(ProductCategoryDto ProductCategoryDto)
        {
            return await _baseService.SendAsync<ResponseDto<ProductCategoryDto>>(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = ProductCategoryDto,
                Url = SD.ProductCategoryAPIBase + "/api/productCategory"
            });
        }
    }
}
