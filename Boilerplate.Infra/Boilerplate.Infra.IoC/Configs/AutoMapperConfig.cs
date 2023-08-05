using Boilerplate.Core.IContracts.Mapper;
using Boilerplate.Infra.Plugins.AutoMapper;
using Boilerplate.Infra.Plugins.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infra.IoC.Configs;

public static class AutoMapperConfig
{
    public static void RegisterAutoMappper(this IServiceCollection services)
    {
        services.AddScoped<IAppMapper, Mapper>();

        services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        }).CreateMapper());
    }
}

