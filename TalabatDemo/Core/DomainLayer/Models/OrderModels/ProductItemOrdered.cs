
using System.ComponentModel.DataAnnotations;


namespace DomainLayer.Models.OrderModels
{
    public class ProductItemOrdered
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name Required")]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "PictureUrl Required")]

        public string PictureUrl { get; set; } = null!;
    }
}
