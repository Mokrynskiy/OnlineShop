using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDTO cartDTO);        
    }
}
