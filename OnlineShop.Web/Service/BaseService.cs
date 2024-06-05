using Newtonsoft.Json;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using System.Net;
using System.Text;
using static OnlineShop.Web.Utility.SD;

namespace OnlineShop.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public async Task<TResult?>SendAsync<TResult>(RequestDto requestDto, bool withBearer = true) where TResult : IResponseDto, new()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("OnlineShopAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiResponse = null;
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }                
                return await GetResponceData<TResult>(await client.SendAsync(message));                
            }
            catch (Exception ex)
            {
                return new TResult
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
            
        }

        private async Task<TResult?> GetResponceData<TResult>(HttpResponseMessage responceMessage) where TResult : IResponseDto, new()
        {
            switch (responceMessage.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Access Denided" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };
                default:
                    var apiContent = await responceMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResult>(apiContent);
            }
        }

    }
}
