using Boilerplate.Core.Models.IModels;
using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.WebUi.Infra.Pagination;
using Boilerplate.WebUi.ViewModels.Base;

namespace Boilerplate.WebUi.ViewModels.Clientes
{
    public class ConsultarClientesViewModel : BaseViewModel, IConsultaViewModel
    {
        public ConsultarClientesViewModel() 
        {
            this.Controller = "Clients";
            this.Action = "Page";
        }

        public string Cpf { get; set; }

        public string Name { get; set; }

        public List<ClientModel> Clients { get; set; }

        public bool Enabled { get; set; }

        public bool AutoComplete { get; set; }
        public StaticPagedListRT<IModel> Itens { get; set; }
        public int PageSize { get; set; } = 2;
    }
}
