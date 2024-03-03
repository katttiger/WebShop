using WebShop.Common.Classes;

namespace WebShop.Data.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } = 10;
        public int Quantity { get; set; }
        public bool IsOnSale { get; set; }
        public string Url { get; set; }

        public CartItem CartItem { get; set; }
    }
}
