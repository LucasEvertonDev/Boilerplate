using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.User;
using Boilerplate.Infra.Plugins.FluentValidation;
using Boilerplate.Infra.Plugins.FluentValidation.CustomValidators;
using Boilerplate.Infra.Utils.Resources;
using FluentValidation;
using FluentValidation.Results;

namespace Boilerplate.Infra.Plugins.FluentValidation.User;

public class CreateUserValidator : BaseValidator<CreateUsersModel>, IValidatorModel<CreateUsersModel>
{
    public CreateUserValidator()
    {
        RuleFor(c => c.Login).SetValidator(new UserNameValidator());
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMessages.EmailRequired);
        RuleFor(c => c.Password).SetValidator(new PasswordValidator());

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMessages.UserEmailInvalid);
        });
    }
}
