namespace OnlineShop.Web.Models
{
    public interface IResponseDto
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }




    public class ResponseDto<TResult> : IResponseDto
    {
        public TResult? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
