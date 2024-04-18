using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IShoppingCartService
    {
        Task<ResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto?> CartAddAsync(CartDTO cartDTO);
        Task<ResponseDto?> RemoveCartAsync(int cartDetailsId);
        Task<ResponseDto?> ApplyDiscountCardAsync(CartDTO cartDTO);
        Task<ResponseDto?> RemoveDiscountCard(CartDTO cartDTO);
    }
}