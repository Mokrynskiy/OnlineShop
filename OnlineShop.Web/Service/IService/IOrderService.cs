using OnlineShop.Services.OrderAPI.Models.Dto;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto<OrderHeaderDto>?> CreateOrder(CartDto cartDTO);
        Task<ResponseDto<IEnumerable<OrderHeaderDto>>?> GetAllOrders(string? userId);
        Task<ResponseDto<IEnumerable<OrderHeaderDto>>?> GetOrder(int orderId);
        Task<ResponseDto<bool>?> UpdateOrderStatus(int orderId, string newStatus);
    }
}
