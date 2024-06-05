using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IDiscountService
    {
        Task<ResponseDto<DiscountDto>?> GetDiscountAsync(string discountCode);
        Task<ResponseDto<List<DiscountDto>>?> GetAllDiscountsAsync();
        Task<ResponseDto<DiscountDto>?> GetDiscountByIdAsync(int id);
        Task<ResponseDto<DiscountDto>?> CreateDiscountAsync(DiscountDto discountDto);
        Task<ResponseDto<DiscountDto>?> UpdateDiscountAsync(DiscountDto discountDto);
        Task<ResponseDto<int>?> DeleteDiscountAsync(int id);
    }
}
