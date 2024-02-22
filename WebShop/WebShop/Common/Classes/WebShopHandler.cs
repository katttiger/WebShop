using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using WebShop.Common.Data;

namespace WebShop.Common.Classes
{
    public class WebShopHandler
    {
        public CollectionData _db = new CollectionData();
        public WebShopHandler() => _db.SeedData();

        public Customer Customer = new();

        public CustomerShopping CustomerShopping = new();
        public bool isLogedIn = false;
        public bool existingUser = true;
        public bool error = false;
        public string errorMessage = string.Empty;


        public List<Product> GetListAsync() => _db.GetList();

        public async Task<Product> GetProductById(int id)
        {
            var result = _db.Products.Find(x => x.Id == id);
            return result;
        }
        public async Task AddToShoppingList(Product product) => _db.ShoppingList.Add(product);

        public void AddCustomer(string name, string adress)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(adress))
                {
                    Customer customer = _db.AddCustomer(name, adress);
                }
            }
            catch (Exception)
            {

                error = true;
                errorMessage = "Adress and name is null or empty";
                throw;
            }

        }
        public void AddCustomerShopping(string customerName, string customerPassword)
        {

            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(customerPassword))
            {
                throw new ArgumentNullException();
            }
            else
            {
                var customerShopper = _db.AddCustomerShopping(customerName, customerPassword);
                CustomerShopping = customerShopper;
            }
        }
    }
}
