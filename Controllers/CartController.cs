using Microsoft.AspNetCore.Mvc;
using Kitabim.Services;

namespace Kitabim.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            ViewBag.CartCount = cart.Items.Sum(i => i.Quantity); // Sepetteki ürün sayısı
            return View(cart);
        }

        public IActionResult AddToCart(int bookId)
        {
            _cartService.AddToCart(bookId);
            var cart = _cartService.GetCart();
            ViewBag.CartCount = cart.Items.Sum(i => i.Quantity); // Sepetteki ürün sayısı
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int bookId)
        {
            _cartService.RemoveFromCart(bookId);
            var cart = _cartService.GetCart();
            ViewBag.CartCount = cart.Items.Sum(i => i.Quantity); // Sepetteki ürün sayısı
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            var cart = _cartService.GetCart();
            ViewBag.CartCount = 0; // Sepetteki ürün sayısı sıfırlama
            return RedirectToAction("Index");
        }
    }
}

