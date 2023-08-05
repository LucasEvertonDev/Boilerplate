using Boilerplate.WebUi.Core.Factories;
using Boilerplate.WebUi.Core.Factories.Interfaces;

namespace Boilerplate.WebUi.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureWeb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IClientModelFactory, ClientModelFactory>();
        services.AddScoped<INavigationPathFactory, NavigationPathFactory>();
        services.AddScoped<ISaveButtonsModelFactory, SaveButtonsModelFactory>();
        return services;
    }
}
