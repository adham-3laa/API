using AutoMapper;
using DomainLayer.Models.Basket;
using Shared.DTOS.BasketDtos;

namespace ServiceLayer.MappingProfiles
{
    internal class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, BasketDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
        }
    }
}