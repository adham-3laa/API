using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstractionLayer;
using Shared.DTOS.Authentication;

namespace ServiceLayer;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IServiceManager, ServiceManager>();
        services.AddScoped<IServiceManager, ServiceManagerWithFactoryDelegate>();

        // Service 
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IBasketService, BasketService>();


        // Factory Delegate Registration
        services.AddScoped<Func<IProductService>>(provider => ()
         => provider.GetRequiredService<IProductService>());
        services.AddScoped<Func<IAuthenticationService>>(provider => ()
         => provider.GetRequiredService<IAuthenticationService>());
        services.AddScoped<Func<IBasketService>>(provider => ()
         => provider.GetRequiredService<IBasketService>());

        services.AddAutoMapper(cfg =>
        {
        }, typeof(ServiceLayer.ServiceLayerAssemblyReference).Assembly);

        services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));
        return services;
    }
}

