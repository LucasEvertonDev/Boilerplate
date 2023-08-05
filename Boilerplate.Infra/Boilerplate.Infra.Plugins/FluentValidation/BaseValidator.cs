using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.IModels;
using Boilerplate.Infra.Utils.Exceptions;
using FluentValidation;

namespace Boilerplate.Infra.Plugins.FluentValidation;

public class BaseValidator<TModel> : AbstractValidator<TModel>, IValidatorModel<TModel> where TModel : IModel
{
    public async Task ValidateModelAsync(TModel model)
    {
        var validationResult = await ValidateAsync(model);

        if (!validationResult.IsValid)
        {
            throw new BusinessException(validationResult.Errors.Select(c => c.ErrorMessage).ToArray());
        }
    }
}
