using Boilerplate.Core.Models.Models.User.Base;

namespace Boilerplate.Core.Models.Models.User;

public class CreateUsersModel : UserModel
{
    public CreateUsersModel()
    {
        Role = "Administrador";
    }
}
