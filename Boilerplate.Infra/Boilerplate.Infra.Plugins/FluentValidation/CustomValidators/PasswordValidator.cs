using Boilerplate.Infra.Utils.Resources;
using FluentValidation;

namespace Boilerplate.Infra.Plugins.FluentValidation.CustomValidators;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator()
    {
        RuleFor(senha => senha).NotEmpty().WithMessage(ResourceMessages.PasswordRequired);
        When(senha => !string.IsNullOrWhiteSpace(senha), () =>
        {
            RuleFor(senha => senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessages.PasswordMinLenghtSixCharacters);
        });
    }
}
