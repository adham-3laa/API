using AutoMapper;
using DomainLayer.Models.Orders;
using DomainLayer.Models.Products;
using Microsoft.Extensions.Configuration;
using Shared.DTOS.Authentication;
using Shared.DTOS.OrderDtos;
using Shared.DTOS.ProductDtos;

namespace ServiceLayer.MappingProfiles
{
    public class productProfile :Profile
    {
        public productProfile(IConfiguration _configuration)
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.ProductBrand.Name))
                                .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.ProductType.Name))
                                .ForMember(dest => dest.PictureUrl, options => options.MapFrom<PictureUrlResolver>());

            CreateMap<ProductType, TypeDto>();
            CreateMap<ProductBrand, BrandDto>();

            CreateMap<AddressDTO, OrderAddress>().ReverseMap();

            CreateMap<Order, OrderToRuternDto>()
                .ForMember(o => o.DeliveryMethod, options => options.MapFrom(src => src.DeliveryMethod.ShortName));
            
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(o => o.ProductName, options => options.MapFrom(src => src.Prouduct.ProductName))
                .ForMember(o => o.PictureUrl, options => options.MapFrom(new OrderPictureUrlResolver(_configuration)));

        }

    }
}
