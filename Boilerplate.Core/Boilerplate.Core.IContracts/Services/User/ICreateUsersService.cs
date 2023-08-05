using Boilerplate.Core.Models.Models.User;

namespace Boilerplate.Core.IContracts.Services.User;

public interface ICreateUsersService
{
    Task ExecuteAsync(CreateUsersModel userModel);
}
