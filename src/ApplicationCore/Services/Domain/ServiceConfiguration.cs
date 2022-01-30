using EStore.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EStore.Domain.Services;

public static class ServiceConfiguration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
           IConfiguration configuration)
    {

        // Repositories Dependency
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}