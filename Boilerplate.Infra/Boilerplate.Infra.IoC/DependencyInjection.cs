using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Boilerplate.Infra.IoC.Configs;

namespace Boilerplate.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(option => option.LowercaseUrls = true);

        // Register db context
        services.RegisterDbContext(configuration);

        services.RegisterIdentity(configuration);

        services.RegisterValidations();

        services.RegisterApplicationServices();

        services.RegisterRepositorys();

        services.RegisterAutoMappper();

        return services;
    }
}
