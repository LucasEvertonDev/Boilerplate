using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Infra.Plugins.Identity;

public class ApplicationUser : IdentityUser
{
    public int Situation { get; set; } = 1;
}
