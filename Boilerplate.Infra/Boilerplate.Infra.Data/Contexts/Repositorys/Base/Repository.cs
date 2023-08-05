using Boilerplate.Core.Domain.Entities.Base;
using Boilerplate.Core.IContracts.Repositorys.BaseRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Boilerplate.Infra.Data.Contexts.Repositorys.Base;

public class Repository<TEntity> : ICreateRepository<TEntity>, IDeleteRepository<TEntity>, IUpdateRepository<TEntity>, ISearchRepository<TEntity> where TEntity : BaseEntity
{
    protected ApplicationDbContext _applicationDbContext;

    public Repository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public Task<TEntity> Delete(TEntity domain)
    {
        _applicationDbContext.Remove(domain);
        return Task.FromResult(domain);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> FindById(Expression<Func<TEntity, bool>> predicate)
    {
        return await _applicationDbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(predicate); ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual async Task<IEnumerable<TEntity>> FindAll()
    {
        return await _applicationDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public Task<TEntity> CreateAsync(TEntity domain)
    {
        _applicationDbContext.AddAsync(domain);
        return Task.FromResult(domain);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public Task<TEntity> UpdateAsync(TEntity domain)
    {
        _applicationDbContext.Entry(domain).State = EntityState.Modified;

        _applicationDbContext.Update(domain);
        return Task.FromResult(domain);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IQueryable<TEntity> Get()
    {
        return _applicationDbContext.Set<TEntity>().AsNoTracking();
    }
}
