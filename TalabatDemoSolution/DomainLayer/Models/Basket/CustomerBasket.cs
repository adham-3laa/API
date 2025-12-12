

namespace DomainLayer.Models.Basket
{
    public class CustomerBasket
    {
        public string Id { get; set; } // GUID , Generated From Client 
        public IEnumerable<BasketItem> Items { get; set; }

       
    }
}