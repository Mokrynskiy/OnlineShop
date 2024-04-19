using OnlineShop.Services.ShoppingCartAPI.Models.DTO;

namespace OnlineShop.Services.ShoppingCartAPI.Service.IService
{
    public interface IDiscountCardService
    {
        Task<DiscountDTO> GetDiscount(string cardCode);
    }
}
