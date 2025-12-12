

using Shared.DTOS.OrderDtos;

namespace ServiceAbstractionLayer
{
    public interface IOrderServices
    {
        Task<OrderToRuternDto> CreateOrderAsync(OrderDto orderDto,string Email);
    }
}
