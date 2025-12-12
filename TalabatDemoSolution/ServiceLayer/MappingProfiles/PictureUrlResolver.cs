using AutoMapper;
using DomainLayer.Models.Products;
using Microsoft.Extensions.Configuration;
using Shared.DTOS.ProductDtos;


namespace ServiceLayer.MappingProfiles
{
    public class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string> 
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrWhiteSpace(source.PictureUrl))
                return string.Empty;
            else
            {
                var url =

                    $"{_configuration.GetSection("Urls")["baseUrl"]}{source.PictureUrl}";
                return url ;
            }
        }
    }
}
