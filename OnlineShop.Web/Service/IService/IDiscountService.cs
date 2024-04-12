using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IDiscountService
    {
        Task<ResponseDto?> GetDiscountAsync(string discountCode);
        Task<ResponseDto?> GetAllDiscountsAsync();
        Task<ResponseDto?> GetDiscountByIdAsync(int id);
        Task<ResponseDto?> CreateDiscountAsync(DiscountDto discountDto);
        Task<ResponseDto?> UpdateDiscountAsync(DiscountDto discountDto);
        Task<ResponseDto?> DeleteDiscountAsync(int id);
    }
}
