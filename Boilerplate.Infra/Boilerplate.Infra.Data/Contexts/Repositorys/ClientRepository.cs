using Boilerplate.Core.Domain.Entities;
using Boilerplate.Core.IContracts.Repositorys.BaseRepos;
using Boilerplate.Core.IContracts.Repositorys.ClientRepos;
using Boilerplate.Core.Models.Models.Clients;
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
}
