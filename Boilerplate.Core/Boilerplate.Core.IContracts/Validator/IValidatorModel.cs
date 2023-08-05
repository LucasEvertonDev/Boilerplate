using Boilerplate.Core.Models.IModels;

namespace Boilerplate.Core.IContracts.Validator;

public interface IValidatorModel<TModel> where TModel : IModel
{
    Task ValidateModelAsync(TModel model);
}
