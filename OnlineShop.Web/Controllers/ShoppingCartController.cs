﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using System.IdentityModel.Tokens.Jwt;

namespace OnlineShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Authorize]
        public async Task<IActionResult> ShoppingCartIndex()
        {
            return View(await LoadCartBaseOnLoggedInUser());
        }

        private async Task<CartDTO> LoadCartBaseOnLoggedInUser()
        {
            var userId = User.Claims.Where(x => x.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault()?.Value;
            var response = await _shoppingCartService.GetCartByUserIdAsync(userId);

            if(response != null && response.IsSuccess)
            {
                var cart = JsonConvert.DeserializeObject<CartDTO>(Convert.ToString(response.Result));
                return cart;
            }

            return new CartDTO();
        }
    }
}
