using AutoMapper;
using DomainLayer.Models.Basket;
using DomainLayer.Models.Identity;
using DomainLayer.Models.Products;
using Shared.DTOS.Authentication;
using Shared.DTOS.BasketDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.MappingProfiles
{
    internal class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<AddressDTO, Address>().ReverseMap();
        }
    }
}
