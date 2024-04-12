using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;
using static OnlineShop.Web.Utility.SD;

namespace OnlineShop.Web.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IBaseService _baseService;
        public DiscountService(IBaseService baseService)
        {
            _baseService = baseService;    
        }
        public async Task<ResponseDto?> CreateDiscountAsync(DiscountDto discountDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = discountDto,
                Url = SD.DiscountAPIBase + "/api/discount"
            });
        }

        public async Task<ResponseDto?> DeleteDiscountAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.DiscountAPIBase + "/api/discount/" + id
            });
        }

        public async Task<ResponseDto?> GetAllDiscountsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.DiscountAPIBase + "/api/discount"
            });
        }

        public async Task<ResponseDto?> GetDiscountAsync(string discountCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.DiscountAPIBase + "/api/discount/GetByCode/"+ discountCode
            });
        }

        public async Task<ResponseDto?> GetDiscountByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.DiscountAPIBase + "/api/discount/"+ id
            });
        }

        public async Task<ResponseDto?> UpdateDiscountAsync(DiscountDto discountDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = discountDto,
                Url = SD.DiscountAPIBase + "/api/discount"
            });
        }
    }
}
