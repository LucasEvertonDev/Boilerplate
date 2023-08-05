using Boilerplate.Core.Domain.Entities;
using Boilerplate.Core.IContracts.Mapper;
using Boilerplate.Core.IContracts.Repositorys.ClientRepos;
using Boilerplate.Core.IContracts.Services.Clients;
using Boilerplate.Core.IContracts.UnitOfWork;
using Boilerplate.Core.IContracts.Validator;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.IContracts.Repositorys.BaseRepos;

namespace Boilerplate.Core.Application.Services.Clients;

public class UpdateClientsService : BaseService, IUpdateClientsService
{
    private IUpdateClientRepository _updateClientRepository;
    private readonly IValidatorModel<UpdateClientsModel> _validatorModel;

    private readonly IAppMapper _mapper;

    public UpdateClientsService(IUpdateClientRepository updateClientRepository,
        IValidatorModel<UpdateClientsModel> validatorModel,
        IAppMapper mapper,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _updateClientRepository = updateClientRepository;
        _validatorModel = validatorModel;
        _mapper = mapper;
    }

    public async Task<ClientModel> ExecuteAsync(UpdateClientsModel clientsModel)
    {
        return await OnTransactionAsync(async () =>
        {
            await ValidateAsync(clientsModel);

            var client = _mapper.Map<Client>(clientsModel);

            client = await _updateClientRepository.UpdateAsync(client);

            return _mapper.Map<ClientModel>(client);
        });
    }

    protected async Task ValidateAsync(UpdateClientsModel clientsModel)
    {
        await _validatorModel.ValidateModelAsync(clientsModel);
    }
}
