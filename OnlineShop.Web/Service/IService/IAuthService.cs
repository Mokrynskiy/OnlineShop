using OnlineShop.Web.Models;

namespace OnlineShop.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto<LoginResponseDto>?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto<string>?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ResponseDto<bool>?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
