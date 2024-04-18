using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;
using static OnlineShop.Web.Utility.SD;

namespace OnlineShop.Web.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IBaseService _baseService;

        public ShoppingCartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyDiscountCardAsync(CartDTO cartDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart/ApplyDiscountCard"
            });
        }

        public async Task<ResponseDto?> CartAddAsync(CartDTO cartDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart/CartAdd"
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId
            });
        }

        public async Task<ResponseDto?> RemoveCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }

        public async Task<ResponseDto?> RemoveDiscountCard(CartDTO cartDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveDiscountCard"
            });
        }
    }
}
