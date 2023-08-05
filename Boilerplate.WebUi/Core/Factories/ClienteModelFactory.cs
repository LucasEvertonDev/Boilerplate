using Azure;
using Boilerplate.Core.Models.IModels;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.WebUi.Controllers;
using Boilerplate.WebUi.Core.Factories.Interfaces;
using Boilerplate.WebUi.Infra.Pagination;
using Boilerplate.WebUi.ViewModels.Base;
using Boilerplate.WebUi.ViewModels.Clientes;
using System.Net.NetworkInformation;

namespace Boilerplate.WebUi.Core.Factories;

public class ClientModelFactory :  IClientModelFactory
{
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
    public Task<ConsultarClientesViewModel> PrepareConsultaClientesModel(List<ClientModel> clientes)
    {
        var model = new ConsultarClientesViewModel()
        {
            Clients = clientes
        };
        var filter = new PagingFilter(model: model, propertiesName: new string[] { "Name", "Cpf" });

        model.Itens = Paging<IModel>(model.Clients.Skip((model.Page ?? 1) * 2).Take(2), model.Page ?? 1, 2, clientes.Count, filter.ToQuery());

        model.Itens.Action = "Page";
        model.Itens.Controller = "Clients";

        return Task.FromResult(model);
    }


    /// <summary>
    /// Realiza a paginação dos itens recebidos;
    /// </summary>
    /// <typeparam name="T">tipo do item paginado.</typeparam>
    /// <param name="itens">itens para paginação.</param>
    /// <param name="page">pagina para exibição.</param>
    /// <param name="pageSize">tamanho da página.</param>
    /// <param name="totalItens">total de itens recuperados.</param>
    /// <param name="query">filtros aplicados.</param>
    /// <param name="action">action a ser acionada.</param>
    /// <returns>lista do itens paginados.</returns>
    protected virtual StaticPagedListRT<T> Paging<T>(IEnumerable<T> itens, int page, int pageSize, int totalItens, string query, string action = "Page", string updateTargetID = "pagination-target-div") where T : class
    {
        return new StaticPagedListRT<T>(itens, page, pageSize, totalItens)
        {
            Controller = "Clients",
            Action = action,
            Query = query,
            UpdateTargetID = updateTargetID,
        };
    }


    /// <summary>
    /// Filtros Paginação
    /// </summary>
    /// <returns></returns>
    private string[] GetFiltersEmbriao()
    {
        return new string[] { "Name", "Cpf" };
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

