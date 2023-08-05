using Boilerplate.Core.IContracts.Repositorys.BaseRepos;
using Boilerplate.Core.IContracts.Repositorys.ClientRepos;
using Boilerplate.Core.IContracts.Repositorys.UserRepos;
using Boilerplate.Infra.Data.Contexts.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infra.IoC.Configs;

public static class RepositorysConfig
{
    public static void RegisterRepositorys(this IServiceCollection services)
    {
        services.AddScoped<ICreateUsersRepository, UserRepository>();
        services.AddScoped<ILoginRepository, UserRepository>();
        services.AddScoped<ISearchUserRepository, UserRepository>();

        services.AddScoped<ICreateClientRepository, ClientRepository>();
        services.AddScoped<ISearchClientRepository, ClientRepository>();
        services.AddScoped<IDeleteClientRepository, ClientRepository>();
        services.AddScoped<IUpdateClientRepository, ClientRepository>();
    }
}
