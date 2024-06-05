using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IBaseService
    {
        Task<TResult?> SendAsync<TResult>(RequestDto requestDto, bool withBearer = true) where TResult : IResponseDto, new();
    }
}
