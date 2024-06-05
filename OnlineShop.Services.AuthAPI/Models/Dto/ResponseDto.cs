namespace OnlineShop.Services.AuthAPI.Models.Dto
{
    public class ResponseDto<TResult>
    {
        public TResult? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
