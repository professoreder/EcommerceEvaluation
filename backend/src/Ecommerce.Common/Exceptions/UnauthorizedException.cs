using System.Net;

namespace Ecommerce.Common.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public int StatusCode => (int)HttpStatusCode.Unauthorized;
}
