

namespace DomainLayer.Exceptions
{
    public sealed class UnauthorizedException(string msg = "Invalid Email or Password")
        :Exception(msg)
    {
    }
}
