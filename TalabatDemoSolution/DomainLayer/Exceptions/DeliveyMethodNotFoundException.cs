

namespace DomainLayer.Exceptions
{
    public class DeliveyMethodNotFoundException(int id): NotFoundException($"DelivaryMethod With Id{id} is not Found! ");

    }

