using Boilerplate.Core.IContracts.Repositorys.UserRepos;
using Boilerplate.Core.IContracts.Services.User;
using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.User;

namespace Boilerplate.Core.Application.Services.User;

public class CreateUsersService : BaseService, ICreateUsersService
{
    private readonly IValidatorModel<CreateUsersModel> _createUserValidatorModel;
    private readonly ICreateUsersRepository _createUserRepository;

    public CreateUsersService(IValidatorModel<CreateUsersModel> createUserValidatorModel,
        ICreateUsersRepository createUserRepository,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _createUserValidatorModel = createUserValidatorModel;
        _createUserRepository = createUserRepository;
    }

    public async Task ExecuteAsync(CreateUsersModel userModel)
    {
        await OnTransactionAsync(async () =>
        {
            await ValidateAsync(userModel);

            await _createUserRepository.CreateAsync(userModel);
        });
    }

    protected async Task ValidateAsync(CreateUsersModel userModel)
    {
        await _createUserValidatorModel.ValidateModelAsync(userModel);
    }
}
