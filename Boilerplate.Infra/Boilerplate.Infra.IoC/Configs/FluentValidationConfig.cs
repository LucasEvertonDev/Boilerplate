using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.User;
using Boilerplate.Infra.Plugins.FluentValidation.Clients;
using Boilerplate.Infra.Plugins.FluentValidation.User;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Infra.IoC.Configs;

public static class ValidatorsConfig
{
    public static void RegisterValidations(this IServiceCollection services)
    {
        services.AddScoped<IValidatorModel<CreateUsersModel>, CreateUserValidator>();
        services.AddScoped<IValidatorModel<LoginModel>, LoginValidator>();
        services.AddScoped<IValidatorModel<CreateClientsModel>, CreateClientsValidator>();
        services.AddScoped<IValidatorModel<UpdateClientsModel>, UpdateClientsValidator>();
    }
}
