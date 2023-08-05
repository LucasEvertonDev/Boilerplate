using Boilerplate.Core.Models.Models.User;
using Boilerplate.Core.Models.Models.User.Base;

namespace Boilerplate.Core.IContracts.Repositorys.UserRepos;

public interface ISearchUserRepository
{
    Task<List<SearchUsersModel>> FindAllAsync(UserModel usersParams);
}
