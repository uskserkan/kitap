using System.Collections.Generic;

namespace Kitabim.Models
{
    public class CartItem
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
