using WebShop.Data.Models;
namespace WebShop.Common.Classes
{
    public class CartItems
    {
        public int id { get; set; }
        public Products Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
