

namespace DomainLayer.Models.Orders
{
    public class OrderItem :BaseEntity<int>
    {
        public ProuductItemOrder Prouduct { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
