using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.User;
using Boilerplate.Infra.Plugins.FluentValidation;
using Boilerplate.Infra.Plugins.FluentValidation.CustomValidators;
using Boilerplate.Infra.Utils.Resources;
using FluentValidation;

namespace Boilerplate.Infra.Plugins.FluentValidation.User;

public class LoginValidator : BaseValidator<LoginModel>, IValidatorModel<LoginModel>
{
    public LoginValidator()
    {
        RuleFor(c => c.Login).SetValidator(new UserNameValidator());
        RuleFor(c => c.Password).SetValidator(new PasswordValidator());
    }
}
