using Boilerplate.Core.Models.Models.Clients;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.WebUi.ViewModels.Clientes;

namespace Boilerplate.WebUi.Core.Factories.Interfaces
{
    public interface IClientModelFactory
    {
        Task<ClienteViewModel> PrepareClienteViewModel();
        Task<ClienteViewModel> PrepareClienteViewModel(ClientModel ClientModel);
        Task<CreateClientsModel> PrepareCreateClientsModelDto(ClienteViewModel clienteViewModel);
        Task<UpdateClientsModel> PrepareUpdateClientsModel(ClienteViewModel clienteViewModel);
        Task<ConsultarClientesViewModel> PrepareConsultaClientesModel(List<ClientModel> clientes);
    }
}