using Boilerplate.Core.IContracts.Repositorys.UserRepos;
using Boilerplate.Core.IContracts.Services.User;
using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.User;
using Boilerplate.Core.Models.Models.User.Base;

namespace Boilerplate.Core.Application.Services.User;

public class LoginService : BaseService, ILoginService
{
    private readonly IValidatorModel<LoginModel> _loginValidatorModel;
    private readonly ILoginRepository _loginRepository;

    public LoginService(IValidatorModel<LoginModel> loginValidatorModel,
        ILoginRepository searchUserRepositor,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _loginValidatorModel = loginValidatorModel;
        _loginRepository = searchUserRepositor;
    }

    public async Task<UserModel> ExecuteAsync(LoginModel loginModel)
    {
        return await OnTransactionAsync(async () =>
        {
            await ValidateAsync(loginModel);

            return await _loginRepository.LoginAsync(loginModel);
        });
    }

    protected async Task ValidateAsync(LoginModel model)
    {
        await _loginValidatorModel.ValidateModelAsync(model);
    }
}
