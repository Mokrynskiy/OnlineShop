using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;

namespace OnlineShop.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;   
        }
        public async Task<IActionResult> ProductCategoryIndex()
        {
            List<ProductCategoryDto>? ProductCategoryList = new();
            ResponseDto? response = await _productCategoryService.GetAllProductCategorysAsync();
            if (response != null && response.IsSuccess)
            {
                ProductCategoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductCategoryDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(ProductCategoryList);
        }
        public async Task<IActionResult> CreateProductCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductCategory(ProductCategoryDto model)
        {
            if(ModelState.IsValid)
            {
                ResponseDto? response = await _productCategoryService.CreateProductCategoryAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Товарная группа успешно добавлена!";
                    return RedirectToAction(nameof(ProductCategoryIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteProductCategory(int productCategoryId)
        {
            ResponseDto? response = await _productCategoryService.GetProductCategoryByIdAsync(productCategoryId);
            if (response != null && response.IsSuccess)
            {
                ProductCategoryDto? model = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductCategoryDto>(Convert.ToString(response.Result));
                if (model != null)
                {                    
                    return View(model);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProductCategory(ProductCategoryDto model)
        {
            ResponseDto? response = await _productCategoryService.DeleteProductCategoryAsync(model.Id);
            if (response != null && response.IsSuccess)
            {
                ProductCategoryDto? responce = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductCategoryDto>(Convert.ToString(response.Result));
                if (model != null)
                {
                    TempData["success"] = "Товарная группа успешно удалена!";
                    return RedirectToAction(nameof(ProductCategoryIndex));
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
