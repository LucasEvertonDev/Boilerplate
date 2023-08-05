using Boilerplate.Core.Domain.IEntities;
using System.Linq.Expressions;

namespace Boilerplate.Core.IContracts.Repositorys.BaseRepos;

public interface ISearchRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IQueryable<T> Get();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> FindAll();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> FindById(Expression<Func<T, bool>> predicate);
}
