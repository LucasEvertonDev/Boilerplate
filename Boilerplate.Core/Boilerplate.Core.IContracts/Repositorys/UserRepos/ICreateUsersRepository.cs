using Boilerplate.Core.Models.Models.User;

namespace Boilerplate.Core.IContracts.Repositorys.UserRepos;

public interface ICreateUsersRepository
{
    Task<CreateUsersModel> CreateAsync(CreateUsersModel userModel);
}
