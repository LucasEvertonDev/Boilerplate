using Boilerplate.Core.Domain.Entities;
using Boilerplate.Infra.Data.Contexts.Configurations;
using Boilerplate.Infra.Plugins.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infra.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Apply customizations Identity
        IdentityConfigurations.Apply(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UpdateDate") != null))
        {
            if (entry.State == EntityState.Modified)
            {
                if (entry.Property("UpdateDate").CurrentValue == null)
                    entry.Property("UpdateDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Added)
            {
                if (entry.Property("CreateDate").CurrentValue == null)
                    entry.Property("CreateDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
