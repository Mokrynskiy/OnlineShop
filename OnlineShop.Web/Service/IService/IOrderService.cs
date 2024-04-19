using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDTO cartDTO);
        Task<ResponseDto?> GetAllOrders(string? userId);
        Task<ResponseDto?> GetOrder(int orderId);
        Task<ResponseDto?> UpdateOrderStatus(int orderId, string newStatus);
    }
}
