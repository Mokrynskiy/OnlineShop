using Newtonsoft.Json;
using OnlineShop.Services.ShoppingCartAPI.Models.DTO;
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

        public async Task<DiscountDTO> GetDiscount(string cardCode)
        {
            var client = _httpClientFactory.CreateClient("DiscountCard");
            var response = await client.GetAsync($"/api/discountCard");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto<DiscountDTO>>(apiContent);

            if (resp != null && resp.IsSuccess)
            {
                return resp.Result;
                //return JsonConvert.DeserializeObject<DiscountDTO>(Convert.ToString(resp.Result));
            }

            return new DiscountDTO();
        }
    }
}
