using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Infra.Utils.Resources;
using FluentValidation;

namespace Boilerplate.Infra.Plugins.FluentValidation.Clients;

public class UpdateClientsValidator : BaseValidator<UpdateClientsModel>, IValidatorModel<UpdateClientsModel>
{
    public UpdateClientsValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceMessages.NameRequired);
    }
}

