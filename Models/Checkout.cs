namespace Kitabim.Models
{
    public class Checkout
    {
        public Address ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
    }
}
