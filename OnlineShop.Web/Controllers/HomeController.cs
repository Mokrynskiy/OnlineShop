using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShoppingCartService _shoppingCartService;

        public HomeController(ILogger<HomeController> logger, IShoppingCartService shoppingCartService)
        {
            _logger = logger;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        [HttpPost]
        [ActionName("ProductionDetails")]
        public async Task<IActionResult> ProductDetails(ProductDto productDto)
        {
            var cart = new CartDTO()
            {
                CartHeaderDTO = new CartHeaderDTO
                {
                    UserId = User.Claims.Where(x => x.Type == JwtClaimTypes.Subject)?.FirstOrDefault()?.Value
                }
            };

            var cartDetails = new CartDetailsDTO()
            {
                Count = productDto.Count,
                ProductId = productDto.Id
            };

            var cartDetailsDTOs = new List<CartDetailsDTO>() { cartDetails };
            cart.CartDetails = cartDetailsDTOs;

            var response = await _shoppingCartService.CartAddAsync(cart);

            if(response != null && response.IsSuccess)
            {
                TempData["success"] = "Товар успешно добавлен в корзину!";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(productDto);
        }
    }
}
