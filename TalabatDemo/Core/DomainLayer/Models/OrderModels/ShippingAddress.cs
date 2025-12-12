
using System.ComponentModel.DataAnnotations;


namespace DomainLayer.Models.OrderModels
{
    public class ShippingAddress
    {
        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName Required")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Street Required")]
        public string Street { get; set; } = null!;
        [Required(ErrorMessage = "City Required")]
        public string City { get; set; } = null!;
        [Required(ErrorMessage = "Country Required")]
        public string Country { get; set; } = null!;
    }
}
