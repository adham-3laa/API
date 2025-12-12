using Microsoft.AspNetCore.Identity;


namespace DomainLayer.Models.IdentityModels
{
    public class ApplicationUser:IdentityUser
    {
        public string DisplayName { get; set; } = null!;
        public Address? Address { get; set; }
    }
}
