using ServiceAbstractionLayer;

namespace ServiceLayer;
internal class ServiceManagerWithFactoryDelegate(Func<IProductService> productFactory,
    Func<IAuthenticationService> authFactory,
    Func<IBasketService> basketFactory
    )
    : IServiceManager
{
    public IProductService ProductService => productFactory.Invoke();

    public IBasketService BasketService => basketFactory.Invoke();

    public IAuthenticationService AuthenticationServices => authFactory.Invoke();

}
