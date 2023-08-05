using Boilerplate.Infra.Plugins.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infra.Data.Contexts.Configurations;

public class IdentityConfigurations
{
    public static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Entity<ApplicationUser>()
            .Ignore(c => c.AccessFailedCount)
            .Ignore(c => c.LockoutEnabled)
            .Ignore(c => c.LockoutEnd)
            .Ignore(c => c.EmailConfirmed)
            .Ignore(c => c.TwoFactorEnabled)
            .Ignore(c => c.PhoneNumberConfirmed);

        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRolesMapping");
        modelBuilder.Entity<ApplicationUser>().ToTable("Users");//to change the name of table.
    }
}
