using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;
using static OnlineShop.Web.Utility.SD;

namespace OnlineShop.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;    
        }
        public async Task<ResponseDto<ProductDto>?> CreateProductAsync(ProductDto ProductDto)
        {
            return await _baseService.SendAsync<ResponseDto<ProductDto>>(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = ProductDto,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto<int>?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto<int>>(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }

        public async Task<ResponseDto<IEnumerable<ProductDto>>?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync<ResponseDto<IEnumerable<ProductDto>>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }
        
        public async Task<ResponseDto<ProductDto>?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto<ProductDto>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.ProductAPIBase + "/api/product/"+ id
            });
        }

        public async Task<ResponseDto<ProductDto>?> UpdateProductAsync(ProductDto ProductDto)
        {
            return await _baseService.SendAsync<ResponseDto<ProductDto>>(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = ProductDto,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }
    }
}
