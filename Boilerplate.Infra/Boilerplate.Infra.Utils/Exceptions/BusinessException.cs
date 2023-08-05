using Boilerplate.Infra.Utils.Exceptions.Base;
using System.Runtime.Serialization;

namespace Boilerplate.Infra.Utils.Exceptions;

[Serializable]
public class BusinessException : ControlServicesException
{
    public List<string> ErrorsMessages { get; set; }

    public BusinessException(params string[] errorsMessage) : base(string.Empty)
    {
        ErrorsMessages = errorsMessage.ToList();
    }

    protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
