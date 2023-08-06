using Boilerplate.Core.Domain.Entities;
using Boilerplate.Core.IContracts.Repositorys.BaseRepos;
using Boilerplate.Core.IContracts.Repositorys.ClientRepos;
using Boilerplate.Core.Models.Models.Base;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.Infra.Data.Contexts.Repositorys.Base;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infra.Data.Contexts.Repositorys;

public class ClientRepository : Repository<Client>, ICreateClientRepository, IUpdateClientRepository, ISearchClientRepository, IDeleteClientRepository
{
    public ClientRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<IEnumerable<Client>> FindAll(SearchClientsModel searchClientsModel)
    {
        return await base.Get().AsNoTracking()
                .Where(a => (string.IsNullOrEmpty(searchClientsModel.Cpf) || searchClientsModel.Cpf == a.Cpf) &&
                    (string.IsNullOrEmpty(searchClientsModel.Name) || a.Name.Contains(searchClientsModel.Name)) &&
                    (string.IsNullOrEmpty(searchClientsModel.Id) || searchClientsModel.Id == a.Id.ToString())
                ).ToListAsync();
    }


    public async Task<PagedResult<Client>> FindAll(PaginationOptions<SearchClientsModel> options)
    {
        var totalElements = await _applicationDbContext.Clients.AsNoTracking()
            .Where(a => (string.IsNullOrEmpty(options.Parameter.Cpf) || options.Parameter.Cpf == a.Cpf) &&
                    (string.IsNullOrEmpty(options.Parameter.Name) || a.Name.Contains(options.Parameter.Name)) &&
                    (string.IsNullOrEmpty(options.Parameter.Id) || options.Parameter.Id == a.Id.ToString())
            ).CountAsync();

        var itens = await base.Get().AsNoTracking()
                .Where(a => (string.IsNullOrEmpty(options.Parameter.Cpf) || options.Parameter.Cpf == a.Cpf) &&
                    (string.IsNullOrEmpty(options.Parameter.Name) || a.Name.Contains(options.Parameter.Name)) &&
                    (string.IsNullOrEmpty(options.Parameter.Id) || options.Parameter.Id == a.Id.ToString())
                )
                .Skip((options.PageNumber - 1) * options.PageSize)
                .Take(options.PageSize)
                .ToListAsync();

        return new PagedResult<Client>(itens, options.PageNumber, options.PageSize, totalElements);
    }
}
