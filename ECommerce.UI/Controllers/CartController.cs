using ECommerce.Business.Abstract;
using ECommerce.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartSessionService _cartSessionService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public async Task<IActionResult> AddToCart(int productId, int page, int category)
        {
            var productToBeAdded = await _productService.GetByIdAsync(productId);
            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your Product, {0} was added successfully to cart", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product", new { page = page, category = category });
        }
    }
}
