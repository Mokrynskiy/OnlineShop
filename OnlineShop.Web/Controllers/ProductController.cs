using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models;
using OnlineShop.Web.Service.IService;

namespace OnlineShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;   
        }
        public async Task<IActionResult> ProductIndex()
        {
            IEnumerable<ProductDto>? productList = null;
            var response = await _productService.GetAllProductsAsync();
            if (response != null && response.IsSuccess)
            {
                productList = response.Result;
                //ProductList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(productList ?? new List<ProductDto>());
        }
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Товар успешно добавлен!";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }
        
        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);
            if (response != null && response.IsSuccess)
            {
                var model = response.Result;
                //ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Товар успешно обновлен!";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var response = await _productService.GetProductByIdAsync(productId);
            if (response != null && response.IsSuccess)
            {
                var model = response.Result;
                //ProductDto? model = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                if (model != null)
                {
                    return View(model);
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDto model)
        {
            var response = await _productService.DeleteProductAsync(model.Id);
            if (response != null && response.IsSuccess)
            {
                //var responce = response.Result;
                //ProductDto? responce = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                if (model != null)
                {
                    TempData["success"] = "Товар успешно удален!";
                    return RedirectToAction(nameof(ProductIndex));
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
