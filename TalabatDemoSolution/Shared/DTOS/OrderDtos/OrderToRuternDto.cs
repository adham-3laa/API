

using Shared.DTOS.Authentication;

namespace Shared.DTOS.OrderDtos
{
    public class OrderToRuternDto
    {
        public Guid Id { get; set; }
        public string USerEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; }
        public AddressDTO Address { get; set; } = null!;
        public string DeliveryMethod { get; set; } = null!;
        public string OrderStatus { get; set; } = null!;
        public ICollection<OrderItemDto> Items { get; set; } = [];
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    } 
}
