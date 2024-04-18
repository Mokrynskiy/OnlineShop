using Newtonsoft.Json;
using OnlineShop.Services.ShoppingCartAPI.Models.Dto;
using OnlineShop.Services.ShoppingCartAPI.Service.IService;

namespace OnlineShop.Services.ShoppingCartAPI.Service
{
    public class DiscountCardService : IDiscountCardService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientFactory"></param>
        public DiscountCardService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<DiscountDto> GetDiscount(string cardCode)
        {
            var client = _httpClientFactory.CreateClient("DiscountCard");
            var response = await client.GetAsync($"/api/discountCard");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<DiscountDto>(Convert.ToString(resp.Result));
            }

            return new DiscountDto();
        }
    }
}
