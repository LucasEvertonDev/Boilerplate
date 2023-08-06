using Boilerplate.Core.Application.Services.Clients;
using Boilerplate.Core.IContracts.Services.Clients;
using Boilerplate.Core.Models.Constants;
using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Infra.Utils.Exceptions;
using Boilerplate.WebUi.Core.Factories.Interfaces;
using Boilerplate.WebUi.Infra.Attributes;
using Boilerplate.WebUi.Infra.Pagination;
using Boilerplate.WebUi.ViewModels.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebUi.Controllers;

public class ClientsController : BaseController
{
    private readonly IClientModelFactory _clientModelFactory;
    private readonly ICreateClientsService _createClientsService;
    private readonly ISearchClientsService _searchClientsService;
    private readonly IUpdateClientsService _updateClientsService;

    public ClientsController(IClientModelFactory clientModelFactory,
        ICreateClientsService createClientsService,
        ISearchClientsService searchClientsService,
        IUpdateClientsService updateClientsService)
    {
        _clientModelFactory = clientModelFactory;
        _createClientsService = createClientsService;
        _searchClientsService = searchClientsService;
        _updateClientsService = updateClientsService;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet, SessionExpire, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Index()
    {
        var viewModel = await _clientModelFactory.PrepareConsultaClientesModel(new ConsultarClientesViewModel());
        return View(viewModel);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPost, SessionExpire, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Index(ConsultarClientesViewModel viewModel)
    {
        var clientes = await _clientModelFactory.PrepareConsultaClientesModel(viewModel);
        return View(clientes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="page"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Page(int? page, string query = null)
    {
        var viewModel = new ConsultarClientesViewModel()
        {
            Action = "Index",
            Controller = "Clients",
            Page = page ?? 1
        };

        PagingFilter.ConverterQueryToFilter(query).ApplyFilterToObject(viewModel);

        await _clientModelFactory.PrepareConsultaClientesModel(viewModel);

        return PartialView("Page", viewModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet, SessionExpire, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create()
    {
        return View(await _clientModelFactory.PrepareClienteViewModel());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPost, SessionExpire, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Create(ClienteViewModel viewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var cliente = await _createClientsService.ExecuteAsync(
                    await _clientModelFactory.PrepareCreateClientsModelDto(viewModel));

                AddSuccess("Cliente cadastrado com sucesso!");
                viewModel.Enabled = false;
            }
        }
        catch (Exception e)
        {
            TratarException(e);
        }
        return View(viewModel);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet, SessionExpire, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Edit(string Id)
    {
        var client = await _searchClientsService.ExecuteAsync(new SearchClientsModel { Id = Id });

        if (client == null || !client.Any())
        {
            throw new BusinessException("Não foi encontrado nenhum item para o id informado");
        }

        var viewModel = await _clientModelFactory.PrepareClienteViewModel(client.First());
        return View(viewModel);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    [HttpPost, SessionExpire, Authorize(Roles = Roles.Admin)]
    public async Task<IActionResult> Edit(ClienteViewModel viewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var cliente = await _updateClientsService.ExecuteAsync(
                    await _clientModelFactory.PrepareUpdateClientsModel(viewModel));

                AddSuccess("Cliente atualizado com sucesso!");
                viewModel.Enabled = false;
            }
        }
        catch (Exception e)
        {
            TratarException(e);
        }
        return View(viewModel);
    }
}
