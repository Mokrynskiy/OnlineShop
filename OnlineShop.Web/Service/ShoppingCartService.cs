using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;


namespace OnlineShop.Web.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IBaseService _baseService;

        public ShoppingCartService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto<bool>?> ApplyDiscountCardAsync(CartDto cartDTO)
        {
            return await _baseService.SendAsync<ResponseDto<bool>>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart/ApplyDiscountCard"
            });
        }

        public async Task<ResponseDto<CartDto>?> CartAddAsync(CartDto cartDTO)
        {
            return await _baseService.SendAsync<ResponseDto<CartDto>>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart/CartAdd"
            });
        }

        public async Task<ResponseDto<CartDto>?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync<ResponseDto<CartDto>>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId
            });
        }

        public async Task<ResponseDto<bool>?> RemoveCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync<ResponseDto<bool>>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart"
            });
        }

        public async Task<ResponseDto<bool>?> RemoveDiscountCard(CartDto cartDTO)
        {
            return await _baseService.SendAsync<ResponseDto<bool>>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveDiscountCard"
            });
        }
    }
}
