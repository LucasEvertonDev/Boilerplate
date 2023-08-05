using Boilerplate.Core.Models.Models.Base;

namespace Boilerplate.Core.Models.Models.User;

public class LoginModel : BaseModel
{
    public string Login { get; set; }
    public string Password { get; set; }
}
