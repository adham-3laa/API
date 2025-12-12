

namespace DomainLayer.Exceptions
{
    public sealed class EmailOrPhoneAlreadyExistException(string msg)
        : Exception($"{msg} Already Exist Try Another One")
    {
    }
}
