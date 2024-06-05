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
        public async Task<ResponseDto<DiscountDto>?> CreateDiscountAsync(DiscountDto discountDto)
        {
            return await _baseService.SendAsync<ResponseDto<DiscountDto>>(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = discountDto,
                Url = SD.DiscountAPIBase + "/api/discount"
            });
        }

        public async Task<ResponseDto<int>?> DeleteDiscountAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto<int>>(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = SD.DiscountAPIBase + "/api/discount/" + id
            });
        }

        public async Task<ResponseDto<List<DiscountDto>>?> GetAllDiscountsAsync()
        {
            return await _baseService.SendAsync<ResponseDto<List<DiscountDto>>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.DiscountAPIBase + "/api/discount"
            });
        }

        public async Task<ResponseDto<DiscountDto>?> GetDiscountAsync(string discountCode)
        {
            return await _baseService.SendAsync<ResponseDto<DiscountDto>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.DiscountAPIBase + "/api/discount/GetByCode/"+ discountCode
            });
        }

        public async Task<ResponseDto<DiscountDto>?> GetDiscountByIdAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto<DiscountDto>>(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = SD.DiscountAPIBase + "/api/discount/"+ id
            });
        }

        public async Task<ResponseDto<DiscountDto>?> UpdateDiscountAsync(DiscountDto discountDto)
        {
            return await _baseService.SendAsync<ResponseDto<DiscountDto>>(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = discountDto,
                Url = SD.DiscountAPIBase + "/api/discount"
            });
        }
    }
}
