using Boilerplate.Core.Models.Models.User;
using Boilerplate.Infra.Utils.Resources;
using FluentValidation;
using FluentValidation.Results;

namespace Boilerplate.Infra.Plugins.FluentValidation.CustomValidators;

internal class UserNameValidator : AbstractValidator<string>
{
    public UserNameValidator()
    {
        RuleFor(UserName => UserName).NotEmpty().WithMessage(ResourceMessages.UserNameRequired);
        When(UserName => !string.IsNullOrWhiteSpace(UserName), () =>
        {
            RuleFor(UserName => UserName).Custom((username, contexto) =>
            {
                if (username.Contains(" "))
                {
                    contexto.AddFailure(new ValidationFailure(nameof(CreateUsersModel.Login), ResourceMessages.UserNameInvalid));
                }

                if (username.Length < 5)
                {
                    contexto.AddFailure(new ValidationFailure(nameof(CreateUsersModel.Login), ResourceMessages.UserNameMinLenght));
                }
            });
        });
    }
}
