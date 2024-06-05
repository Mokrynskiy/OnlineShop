using OnlineShop.Services.OrderAPI.Models.Dto;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;

namespace OnlineShop.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;    
        }

        public async Task<ResponseDto<OrderHeaderDto>?> CreateOrder(CartDto cartDTO)
        {
            return await _baseService.SendAsync<ResponseDto<OrderHeaderDto>>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDto<IEnumerable<OrderHeaderDto>>?> GetAllOrders(string? userId)
        {
            return await _baseService.SendAsync<ResponseDto<IEnumerable<OrderHeaderDto>>>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.OrderAPIBase + "/api/order/GetOrders/" + userId
            });
        }

        public async Task<ResponseDto<IEnumerable<OrderHeaderDto>>?> GetOrder(int orderId)
        {
            return await _baseService.SendAsync<ResponseDto<IEnumerable<OrderHeaderDto>>>(new RequestDto()
            {
                ApiType = SD.ApiType.GET,                
                Url = SD.OrderAPIBase + "/api/order/GetOrder/" + orderId
            });
        }

        public async Task<ResponseDto<bool>?> UpdateOrderStatus(int orderId, string newStatus)
        {
            return await _baseService.SendAsync<ResponseDto<bool>>(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = newStatus,
                Url = SD.OrderAPIBase + "/api/order/UpdateOrderStatus/"+orderId
            });
        }
    }
}
