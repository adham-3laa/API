using System.ComponentModel.DataAnnotations;


namespace DomainLayer.Models.OrderModels
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public ProductItemOrdered productItemOrdered { get; set; } = null!;

        [Required(ErrorMessage ="Price Required")]
        public decimal Price { get; set; }// Price per unit.

        [Required(ErrorMessage = "Quantity Required")]
        public int Quantity { get; set; }//Number of units ordered.

    }
}
