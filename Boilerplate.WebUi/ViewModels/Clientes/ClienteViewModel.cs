using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.WebUi.ViewModels.Base;

namespace Boilerplate.WebUi.ViewModels.Clientes
{
    public class ClienteViewModel : ClientModel, IViewModel
    {
        public bool Enabled { get; set; } = true;

        public bool AutoComplete { get; set; }
    }
}
