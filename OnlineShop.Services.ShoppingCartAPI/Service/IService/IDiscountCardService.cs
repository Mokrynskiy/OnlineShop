using OnlineShop.Services.ShoppingCartAPI.Models.Dto;

namespace OnlineShop.Services.ShoppingCartAPI.Service.IService
{
    public interface IDiscountCardService
    {
        Task<DiscountDto> GetDiscount(string cardCode);
    }
}
