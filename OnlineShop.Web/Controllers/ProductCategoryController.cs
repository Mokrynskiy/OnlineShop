using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;
using System.Collections.Generic;

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
            IEnumerable<ProductDto> productCategoryList = null;
            var response = await _productCategoryService.GetAllProductCategorysAsync();
            if (response != null && response.IsSuccess)
            {
                //ProductCategoryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductCategoryDto>>(Convert.ToString(response.Result));
                productCategoryList = response.Result;
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productCategoryList ?? new List<ProductDto>());
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
                var response = await _productCategoryService.CreateProductCategoryAsync(model);
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
            var response = await _productCategoryService.GetProductCategoryByIdAsync(productCategoryId);
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
            var response = await _productCategoryService.DeleteProductCategoryAsync(model.Id);
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
