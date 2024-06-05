using Newtonsoft.Json;
using OnlineShop.Services.OrderAPI.Models.DTO;
using OnlineShop.Services.OrderAPI.Service.IService;

namespace OnlineShop.Services.OrderAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var response = await client.GetAsync($"/api/product");
            var apiContent = await response.Content.ReadAsStringAsync();
            //var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            var resp = JsonConvert.DeserializeObject<ResponseDto<IEnumerable<ProductDto>>>(apiContent);

            if (resp.IsSuccess)
            {
                //return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(resp.Result));
                return resp.Result;
            }

            return new List<ProductDto>();
        }
    }
}
