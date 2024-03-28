using CoverGo.Task.Application;
using CoverGo.Task.Application.Discount;
using CoverGo.Task.Domain;
using CoverGo.Task.Domain.Discount.Entities;
using CoverGo.Task.Infrastructure.Persistence.InMemory;

namespace Microsoft.Extensions.DependencyInjection;

public static class PersistenceInMemoryDI
{
    public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
    {
        services.AddScoped<ICompaniesQuery, InMemoryCompaniesRepository>();
        services.AddScoped<IPlansQuery, InMemoryPlansRepository>();
        services.AddScoped<ICompaniesWriteRepository, InMemoryCompaniesRepository>();
        services.AddScoped<IPlansWriteRepository, InMemoryPlansRepository>();

        services.AddScoped<IProductsQuery, InMemoryProductsRepository>();
        services.AddScoped<IProductsWriteRepository, InMemoryProductsRepository>();

        services.AddScoped<IShoppingCartQuery, InMemoryShoppingCartRepository>();
        services.AddScoped<IShoppingCartWriteRepository, InMemoryShoppingCartRepository>();

        services.AddScoped<IDiscountRuleQuery, InMemoryDiscountRuleRepository>();
        services.AddScoped<IDiscountRuleWriteRepository, InMemoryDiscountRuleRepository>();
        services.AddSingleton(new List<DiscountRule>());
        services.AddSingleton(new List<ShoppingCart>());
        services.AddSingleton(new List<Product>());
        return services;
    }
}
