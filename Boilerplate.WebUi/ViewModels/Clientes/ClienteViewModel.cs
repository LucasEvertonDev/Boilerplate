using Boilerplate.Core.Models.Models.Clients.Base;
using Boilerplate.WebUi.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace Boilerplate.WebUi.ViewModels.Clientes;

public class ClienteViewModel : ClientModel, IViewModel
{ 
    [Required(ErrorMessage = "Campo é obrigatório")]
    public override string Name { get => base.Name; set => base.Name = value; }

    public bool Enabled { get; set; } = true;

    public bool AutoComplete { get; set; }
}
