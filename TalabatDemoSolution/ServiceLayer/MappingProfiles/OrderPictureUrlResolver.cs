
using AutoMapper;
using DomainLayer.Models.Orders;
using Microsoft.Extensions.Configuration;
using Shared.DTOS.OrderDtos;

namespace ServiceLayer.MappingProfiles
{
    public class OrderPictureUrlResolver(IConfiguration _configuration) : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.Prouduct.PictureUrl))
                return string.Empty;
            else
            {
                var url =

                    $"{_configuration.GetSection("Urls")["baseUrl"]}{source.Prouduct.PictureUrl}";
                return url;
            }
        }
    }
}
