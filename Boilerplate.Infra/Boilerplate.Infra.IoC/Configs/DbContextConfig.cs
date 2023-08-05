using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Infra.Data.Contexts;
using Boilerplate.Infra.Data.Contexts.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infra.IoC.Configs;

public static class DbContextConfig
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        //É obrigatório definir a versão do My Sql 
        services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
