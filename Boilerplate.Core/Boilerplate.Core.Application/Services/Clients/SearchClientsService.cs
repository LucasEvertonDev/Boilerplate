using Boilerplate.Core.IContracts.Mapper;
using Boilerplate.Core.IContracts.Services.Clients;
using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.IContracts.Repositorys.BaseRepos;
using Boilerplate.Core.Models.Models.Base;

namespace Boilerplate.Core.Application.Services.Clients;


public class SearchClientsService : BaseService, ISearchClientsService
{
    private ISearchClientRepository _searchClientRepository;
    private readonly IAppMapper _mapper;

    public SearchClientsService(ISearchClientRepository searchClientRepository,
        IAppMapper mapper,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _searchClientRepository = searchClientRepository;
        _mapper = mapper;
    }

    public async Task<List<ClientModel>> ExecuteAsync(SearchClientsModel searchClientsModel)
    {
        return await OnTransactionAsync(async () =>
        {
            return _mapper.Map<List<ClientModel>>(await _searchClientRepository.FindAll(searchClientsModel));
        });
    }

    public async Task<PagedResult<ClientModel>> ExecuteAsync(PaginationOptions<SearchClientsModel> searchClientsModel)
    {
        return await OnTransactionAsync(async () =>
        {
            return _mapper.Map<PagedResult<ClientModel>>(await _searchClientRepository.FindAll(searchClientsModel));
        });
    }
}
