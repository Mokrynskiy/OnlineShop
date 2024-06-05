namespace OnlineShop.Services.OrderAPI.Models.DTO
{
    public class ResponseDto<TResult>
    {
        public TResult? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
