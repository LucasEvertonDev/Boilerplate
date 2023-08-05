using Boilerplate.Core.Application.Services;
using Boilerplate.Core.Domain.Entities;
using Boilerplate.Core.IContracts.Mapper;
using Boilerplate.Core.IContracts.Repositorys.ClientRepos;
using Boilerplate.Core.IContracts.Services.Clients;
using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;

namespace Boilerplate.Core.Application.Services.Clients;

public class CreateClientsService : BaseService, ICreateClientsService
{
    private ICreateClientRepository _createClientRepository;
    private readonly IValidatorModel<CreateClientsModel> _createClientsValidatorModel;
    private readonly IAppMapper _mapper;

    public CreateClientsService(ICreateClientRepository createClientRepository,
        IValidatorModel<CreateClientsModel> createClientsValidatorModel,
        IAppMapper mapper,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _createClientRepository = createClientRepository;
        _createClientsValidatorModel = createClientsValidatorModel;
        _mapper = mapper;
    }

    public async Task<ClientModel> ExecuteAsync(CreateClientsModel clientsModel)
    {
        return await OnTransactionAsync(async () =>
        {
            await ValidateAsync(clientsModel);

            var client = _mapper.Map<Client>(clientsModel);

            client = await _createClientRepository.CreateAsync(client);

            return _mapper.Map<ClientModel>(client);
        });
    }

    protected async Task ValidateAsync(CreateClientsModel clientsModel)
    {
        await _createClientsValidatorModel.ValidateModelAsync(clientsModel);
    }
}
