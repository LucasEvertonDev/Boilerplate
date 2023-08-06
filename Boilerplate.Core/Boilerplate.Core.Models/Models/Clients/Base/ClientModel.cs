using Boilerplate.Core.Models.Models.Base;

namespace Boilerplate.Core.Models.Models.Clients.Base;

public class ClientModel : BaseModel
{
    public virtual string Id { get; set; }
    public string Cpf { get; set; }
    public virtual string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string PhoneNumber { get; set; }
}
