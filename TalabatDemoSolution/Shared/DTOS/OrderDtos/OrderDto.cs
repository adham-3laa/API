

using Shared.DTOS.Authentication;

namespace Shared.DTOS.OrderDtos
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public string DeliveryMethodId { get; set; }
        public AddressDTO Address { get; set; }
    }
}
