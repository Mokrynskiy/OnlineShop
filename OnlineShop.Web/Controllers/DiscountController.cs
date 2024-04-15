using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;

namespace OnlineShop.Web.Controllers
{
    public class DiscountController : Controller
    {
        IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;   
        }
        public async Task<IActionResult> DiscountIndex()
        {
            List<DiscountDto>? discountList = new();
            ResponseDto? response = await _discountService.GetAllDiscountsAsync();
            if (response != null && response.IsSuccess)
            {
                discountList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DiscountDto>>(Convert.ToString(response.Result));
            }
            return View(discountList);
        }
        public async Task<IActionResult> CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(DiscountDto discountDto)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _discountService.CreateDiscountAsync(discountDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("DiscountIndex");
                }
            }
            return View(discountDto);
        }
        public async Task<IActionResult> DeleteDiscount(int discountId)
        {
            ResponseDto? response = await _discountService.GetDiscountByIdAsync(discountId);
            if (response != null && response.IsSuccess)
            {
                DiscountDto? model = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountDto>(Convert.ToString(response.Result));
                if (model != null)
                {
                    return View(model);
                }
            }
            return NotFound();
        }
    }
}
