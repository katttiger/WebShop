using WebShop.Components.UIComponents;
using WebShop.Common.Data;
namespace WebShop.Common.Classes
{
    public class CustomerShopping
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Shoppinglist { get; set; }

        public CustomerShopping() { }
        public CustomerShopping(int id, Customer customer, List<Product> shoppinglist) => (Id, Customer, Shoppinglist) = (id, customer, shoppinglist);
    }
}
