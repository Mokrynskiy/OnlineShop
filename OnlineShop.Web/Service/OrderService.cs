using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using OnlineShop.Web.Utility;
using static OnlineShop.Web.Utility.SD;

namespace OnlineShop.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;    
        }

        public async Task<ResponseDto?> CreateOrder(CartDTO cartDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = cartDTO,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        
    }
}
