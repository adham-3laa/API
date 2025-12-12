

namespace DomainLayer.Exceptions.ForbiddenExceptions
{
    public sealed class GetOrderByIdException(string email) 
        : ForbiddenException($"This Email {email} does't allowed to Check this Info")
    {
    }
}
