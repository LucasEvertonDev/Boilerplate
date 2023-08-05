using Boilerplate.Core.Models.Models.User;
using Boilerplate.Core.Models.Models.User.Base;

namespace Boilerplate.Core.IContracts.Repositorys.UserRepos;

public interface ILoginRepository
{
    Task<UserModel> LoginAsync(LoginModel loginModel);
}
