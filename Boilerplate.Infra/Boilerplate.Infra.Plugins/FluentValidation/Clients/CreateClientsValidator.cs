using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Infra.Plugins.FluentValidation;
using Boilerplate.Infra.Utils.Resources;
using FluentValidation;

namespace Boilerplate.Infra.Plugins.FluentValidation.Clients;

public class CreateClientsValidator : BaseValidator<CreateClientsModel>, IValidatorModel<CreateClientsModel>
{
    public CreateClientsValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceMessages.NameRequired);
    }
}
