using Boilerplate.Infra.Utils.Exceptions.Base;
using Boilerplate.Infra.Utils.Resources;
using System.Runtime.Serialization;

namespace Boilerplate.Infra.Utils.Exceptions;

[Serializable]
public class BadCredentialsException : ControlServicesException
{
    public BadCredentialsException() : base(ResourceMessages.UserOrPasswordInvalid)
    {

    }

    protected BadCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
