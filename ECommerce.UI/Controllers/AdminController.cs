using ECommerce.Business.Abstract;
using ECommerce.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{

    //public class AdminController : Controller
    //{
    //    [Authorize(Roles = "Admin")]
    //    public IActionResult Index()
    //    {
    //        var username = User.Identity.Name;
    //        TempData["username"] = username;
    //        return View();
    //    }
    //    [Authorize(Roles = "Admin,Editor")]
    //    public IActionResult Index2()
    //    {
    //        return View();
    //    }
    //}

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(int page = 1, int category = 0)
        {
            int pageSize = 10;
            var items = await _productService.GetAllByCategoryAsync(category);

            var model = new ProductListViewModel
            {
                Products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentPage = page,
                CurrentCategory = category
            };
            return View(model);
        }


        public async Task<IActionResult> RemoveProduct(int productId, int page = 1, int category = 0)
        {
           // await _productService.DeleteProduct(productId);
            TempData["message"] = "Product deleted successfully";
            return RedirectToAction("Index", new { page = page, category = category });
        }


    }
}
