using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;

namespace Boilerplate.Core.IContracts.Services.Clients;

public interface ISearchClientsService
{
    Task<List<ClientModel>> ExecuteAsync(SearchClientsModel searchClientsModel);
}
