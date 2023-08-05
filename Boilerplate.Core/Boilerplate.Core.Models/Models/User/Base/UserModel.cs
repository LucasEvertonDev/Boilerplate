using Boilerplate.Core.Models.Models.Base;

namespace Boilerplate.Core.Models.Models.User.Base;

public class UserModel : BaseModel
{
    public string Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
