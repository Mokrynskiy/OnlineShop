using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Services.AuthAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
