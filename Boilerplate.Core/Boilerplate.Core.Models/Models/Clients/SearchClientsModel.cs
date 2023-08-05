using Boilerplate.Core.Models.Models.Base;
using Boilerplate.Core.Models.Models.Clients.Base;

namespace Boilerplate.Core.Models.Models.Clients;

public class SearchClientsModel : BaseModel
{
    public string Id { get; set; }
    public string Cpf { get; set; }
    public string Name { get; set; }
}
