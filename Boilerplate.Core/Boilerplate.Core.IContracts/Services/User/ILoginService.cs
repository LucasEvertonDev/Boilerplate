using Boilerplate.Core.Models.Models.User;
using Boilerplate.Core.Models.Models.User.Base;

namespace Boilerplate.Core.IContracts.Services.User;

public interface ILoginService
{
    Task<UserModel> ExecuteAsync(LoginModel loginModel);
}
