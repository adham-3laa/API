using AutoMapper;
using DomainLayer.Models.Identity;
using Shared.DTOS.Authentication;


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
