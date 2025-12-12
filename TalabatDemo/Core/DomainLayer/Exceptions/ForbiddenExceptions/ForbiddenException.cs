

namespace DomainLayer.Exceptions.ForbiddenExceptions
{
    public abstract class ForbiddenException(string msg) 
        :Exception(msg)
    {
    }
}
