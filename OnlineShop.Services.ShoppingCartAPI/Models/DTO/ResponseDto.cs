namespace OnlineShop.Services.ShoppingCartAPI.Models.DTO
{
    public class ResponseDto<TResult>
    {
        public TResult? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
