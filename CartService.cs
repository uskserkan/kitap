using Microsoft.AspNetCore.Http;
using Kitabim.Helpers;
using Kitabim.Data;
using Kitabim.Models;
using System.Text.Json;

namespace Kitabim.Services
{
    public class CartService
    {
        private readonly KitabimDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(KitabimDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public ShoppingCart GetCart()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }

            var cart = session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return cart;
        }

        public void SaveCart(ShoppingCart cart)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null)
            {
                throw new InvalidOperationException("Session is not available.");
            }

            session.SetObjectAsJson("Cart", cart);
        }
        
        public void AddToCart(int bookId)
        {
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.BookId == bookId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    BookId = bookId,
                    Book = _context.Books.Find(bookId),
                    Quantity = 1
                };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            SaveCart(cart);
        }

        public void RemoveFromCart(int bookId)
        {
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(i => i.BookId == bookId);

            if (cartItem != null)
            {
                cart.Items.Remove(cartItem);
                SaveCart(cart);
            }
        }

        public void ClearCart()
        {
            var cart = new ShoppingCart();
            SaveCart(cart);
        }

        internal decimal GetTotalAmount()
        {
            throw new NotImplementedException();
        }
    }
}






     

  
