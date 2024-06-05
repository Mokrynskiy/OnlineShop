using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IShoppingCartService
    {
        Task<ResponseDto<CartDto>?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto<CartDto>?> CartAddAsync(CartDto cartDTO);
        Task<ResponseDto<bool>?> RemoveCartAsync(int cartDetailsId);
        Task<ResponseDto<bool>?> ApplyDiscountCardAsync(CartDto cartDTO);
        Task<ResponseDto<bool>?> RemoveDiscountCard(CartDto cartDTO);
    }
}