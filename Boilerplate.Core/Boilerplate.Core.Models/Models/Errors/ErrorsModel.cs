using Boilerplate.Core.Models.Models.Base;

namespace Boilerplate.Core.Models.Models.Errors;

public class ErrorsModel : BaseModel
{
    public ErrorsModel() { }

    public string[] Messages { get; set; }

    public ErrorsModel(params string[] message)
    {
        Messages = message;
    }
}
