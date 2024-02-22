using Common.Interface;

namespace WebShop.Common.Classes
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Url { get; set; }

        public bool IsOnSale { get; set; }
        public Product(int id, string name, string description, double price, int quantity, string url, bool isOnSale)
            => (Id, Name, Description, Price, Quantity,  Url, IsOnSale) = (id, name, description, price, quantity, url, isOnSale);
        public Product()
        {
                
        }
    }
}
