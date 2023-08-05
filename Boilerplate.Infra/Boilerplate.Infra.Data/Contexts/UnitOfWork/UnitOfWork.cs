using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Infra.Utils;

namespace Boilerplate.Infra.Data.Contexts.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task RollbackAsync()
    {
        await _context.DisposeAsync();
    }
}
