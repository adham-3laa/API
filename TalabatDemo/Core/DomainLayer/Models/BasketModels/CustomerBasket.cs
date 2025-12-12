

namespace DomainLayer.Models.BasketModels
{
    public class CustomerBasket
    {
        public string Id { get; set; } //GUID Created From [front-end]
        public ICollection<BasketItem> Items { get; set; }
    }
}
