
namespace Kitabim.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}