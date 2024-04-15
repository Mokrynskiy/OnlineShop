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
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(discountList);
        }
        public async Task<IActionResult> CreateDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(DiscountDto model)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _discountService.CreateDiscountAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Скидка успешно добавлена!";
                    return RedirectToAction(nameof(DiscountIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
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
        [HttpPost]
        public async Task<IActionResult> DeleteDiscount(DiscountDto model)
        {
            ResponseDto? response = await _discountService.DeleteDiscountAsync(model.Id);
            if (response != null && response.IsSuccess)
            {
                DiscountDto? responce = Newtonsoft.Json.JsonConvert.DeserializeObject<DiscountDto>(Convert.ToString(response.Result));
                if (model != null)
                {
                    TempData["success"] = "Скидка успешно удалена!";
                    return RedirectToAction(nameof(DiscountIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return NotFound();
        }
    }
}
