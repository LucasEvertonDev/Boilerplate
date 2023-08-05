using Boilerplate.Core.Domain.IEntities;

namespace Boilerplate.Core.IContracts.Repositorys.BaseRepos;
public interface IUpdateRepository<T> where T : IEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T domain);
}
