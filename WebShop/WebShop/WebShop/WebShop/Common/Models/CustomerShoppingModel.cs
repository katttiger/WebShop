using WebShop.Components.UIComponents;

namespace WebShop.Common.Classes
{
    public class CustomerShoppingModel
    {
        public int Id { get; set; }
        public Customer Customer{ get; set; }
        public List<Product> ShoppingList { get; set; }

        //En shoppinglista kan bara ha en kund
        //En shoppinglista kan ha flera produkter
    }
}
