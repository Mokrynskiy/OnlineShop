using OnlineShop.Services.AuthAPI.Models;

namespace OnlineShop.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(AppUser user, IEnumerable<string> roles);
    }
}
