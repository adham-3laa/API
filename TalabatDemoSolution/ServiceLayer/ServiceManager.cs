using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ServiceAbstractionLayer;
using Shared.DTOS.Authentication;

namespace ServiceLayer
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper,
    IBasketRepository basketRepository
    , UserManager<ApplicationUser> userManager
    , IOptions<JWTOptions> options)
    //: IServiceManager
    {
        private readonly Lazy<IProductService> _lazyProductService =
            new(() => new ProductService(unitOfWork, mapper));
        public IProductService ProductService => _lazyProductService.Value;


        private readonly Lazy<IBasketService> _lazyBasketService =
        new(() => new BasketService(basketRepository, mapper));
        public IBasketService BasketService => _lazyBasketService.Value;


        private readonly Lazy<IAuthenticationService> _lazyAuthenticationService =
       new(() => new AuthenticationService(userManager, mapper, options));
        public IAuthenticationService AuthenticationService => _lazyAuthenticationService.Value;


        
    }


}
