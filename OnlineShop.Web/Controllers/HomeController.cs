using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using System.Diagnostics;


namespace OnlineShop.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IShoppingCartService shoppingCartService, IProductService productService)
    {
        _logger = logger;
        _shoppingCartService = shoppingCartService;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        List<ProductDto> list = new();
        var response = await _productService.GetAllProductsAsync();
        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
        }
        return View(list);
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
        var cart = new CartDto()
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

    public async Task<IActionResult> Details(int productId)
    {
        ProductDto model = new();
        var response = await _productService.GetProductByIdAsync(productId);
        if (response != null && response.IsSuccess)
        {
            model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
        }
        return View(model);
    }
}
