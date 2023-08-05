using Boilerplate.Core.Application.Services;
using Boilerplate.Core.Application.Services.Clients;
using Boilerplate.Core.Application.Services.User;
using Boilerplate.Core.IContracts.Services.Clients;
using Boilerplate.Core.IContracts.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infra.IoC.Configs;

public static class ServicesConfig
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateUsersService, CreateUsersService>();
        services.AddScoped<ILoginService, LoginService>();

        services.AddScoped<ICreateClientsService, CreateClientsService>();
        services.AddScoped<ISearchClientsService, SearchClientsService>();
        services.AddScoped<IUpdateClientsService, UpdateClientsService>();
    }
}

