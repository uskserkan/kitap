using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Kitabim.Models;
using Kitabim.Services;
using Kitabim.Data;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Kitabim.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CartService _cartService;
        private readonly PaymentService _paymentService;
        private readonly KitabimDbContext _context;

        public CheckoutController(CartService cartService, PaymentService paymentService, KitabimDbContext context)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            if (cart.Items.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(new Checkout());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Checkout checkout)
        {
            if (!ModelState.IsValid)
            {
                return View(checkout);
            }

            var result = _paymentService.ProcessPayment(checkout);
            if (result)
            {
                // Sipariş oluşturma
                var order = new Order
                {
                    ShippingAddress = $"{checkout.ShippingAddress.AddressLine1}, {checkout.ShippingAddress.City}, {checkout.ShippingAddress.State}, {checkout.ShippingAddress.PostalCode}, {checkout.ShippingAddress.Country}",
                    OrderDate = DateTime.Now,
                    TotalAmount = 100M,
                    Status = "Onaylandı"
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                _cartService.ClearCart();
                return RedirectToAction("Success");
            }

            ModelState.AddModelError("", "Ödeme işlemi başarısız oldu. Lütfen tekrar deneyin.");
            return View(checkout);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}


