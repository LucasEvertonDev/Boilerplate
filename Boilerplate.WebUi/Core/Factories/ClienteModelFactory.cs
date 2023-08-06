using Boilerplate.Core.IContracts.Services.Clients;
using Boilerplate.Core.Models.IModels;
using Boilerplate.Core.Models.Models.Base;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.WebUi.Core.Factories.Interfaces;
using Boilerplate.WebUi.Infra.Pagination;
using Boilerplate.WebUi.ViewModels.Clientes;

namespace Boilerplate.WebUi.Core.Factories;

public class ClientModelFactory : BaseModalFactory, IClientModelFactory
{
    private readonly ISearchClientsService _searchClientsService;

    public ClientModelFactory(ISearchClientsService searchClientsService)
    {
        _searchClientsService = searchClientsService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<ClienteViewModel> PrepareClienteViewModel()
    {
        return Task.FromResult(new ClienteViewModel { BirthDate = DateTime.Now.Date });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<ClienteViewModel> PrepareClienteViewModel(ClientModel ClientModel)
    {
        return Task.FromResult(new ClienteViewModel
        {
            Cpf = ClientModel.Cpf,
            BirthDate = ClientModel.BirthDate,
            Id = ClientModel.Id,
            Name = ClientModel.Name,
            PhoneNumber = ClientModel.PhoneNumber
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<CreateClientsModel> PrepareCreateClientsModelDto(ClienteViewModel clienteViewModel)
    {
        return Task.FromResult(new CreateClientsModel
        {
            Cpf = String.IsNullOrEmpty(clienteViewModel.Cpf) ? "" : String.Join("", System.Text.RegularExpressions.Regex.Split(clienteViewModel.Cpf, @"[^\d]")),
            BirthDate = clienteViewModel.BirthDate,
            Id = clienteViewModel.Id,
            Name = clienteViewModel.Name,
            PhoneNumber = String.IsNullOrEmpty(clienteViewModel.PhoneNumber) ? "" : String.Join("", System.Text.RegularExpressions.Regex.Split(clienteViewModel.PhoneNumber, @"[^\d]")),
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clientes"></param>
    /// <returns></returns>
    public async Task<ConsultarClientesViewModel> PrepareConsultaClientesModel(ConsultarClientesViewModel viewModel)
    {
        var clients = await _searchClientsService.ExecuteAsync(new PaginationOptions<SearchClientsModel>()
        {
            Parameter = new SearchClientsModel
            {
                Cpf = viewModel.Cpf,
                Name = viewModel.Name
            },
            PageNumber = viewModel.Page ?? 1,
            PageSize = viewModel.PageSize,
        });

        viewModel.Clients = clients.Items.ToList();

        var filter = new PagingFilter(model: viewModel, propertiesName: new string[] { "Name", "Cpf" });

        viewModel.Itens = Paging<IModel>(viewModel.Clients, clients.PageNumber, clients.PageSize, clients.TotalElements, filter.ToQuery());

        viewModel.Itens.Action = "Page";
        viewModel.Itens.Controller = "Clients";

        return viewModel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="clienteViewModel"></param>
    /// <returns></returns>
    public Task<UpdateClientsModel> PrepareUpdateClientsModel(ClienteViewModel clienteViewModel)
    {
        return Task.FromResult(new UpdateClientsModel
        {
            Cpf = String.IsNullOrEmpty(clienteViewModel.Cpf) ? "" : String.Join("", System.Text.RegularExpressions.Regex.Split(clienteViewModel.Cpf, @"[^\d]")),
            BirthDate = clienteViewModel.BirthDate,
            Id = clienteViewModel.Id,
            Name = clienteViewModel.Name,
            PhoneNumber = String.IsNullOrEmpty(clienteViewModel.PhoneNumber) ? "" : String.Join("", System.Text.RegularExpressions.Regex.Split(clienteViewModel.PhoneNumber, @"[^\d]")),
        });
    }
}

