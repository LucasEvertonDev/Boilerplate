using Boilerplate.Core.Domain.Entities;
using Boilerplate.Core.Models.Models.Base;
using Boilerplate.Core.Models.Models.Clients;

namespace Boilerplate.Core.IContracts.Repositorys.BaseRepos;

public interface ISearchClientRepository : ISearchRepository<Client>
{
    Task<IEnumerable<Client>> FindAll(SearchClientsModel searchClientsModel);
    Task<PagedResult<Client>> FindAll(PaginationOptions<SearchClientsModel> options);
}
