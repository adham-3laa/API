using System;
namespace DomainLayer.Contracts
{
    public interface IDataSeeding
    {
        public Task DataSeedAsync();
        Task InitializeIdentityAsync();

    }
}
