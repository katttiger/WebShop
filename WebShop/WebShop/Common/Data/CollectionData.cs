using Common;
using Microsoft.AspNetCore.SignalR;
using System.Linq.Expressions;
using System.Reflection;
using WebShop.Common.Classes;


namespace WebShop.Common.Data
{
    public class CollectionData
    {
        public List<Product> Products = new List<Product>();

        public List<Product> ShoppingList = new List<Product>();

        public List<Customer> CustomerList = new List<Customer>();

        public List<CustomerShopping> CustomerShoppingList = new List<CustomerShopping>();
        public void SeedData()
        {
            Product product1 = new Product(1, "Grå nalle",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                10, 5, "https://quickbutik.imgix.net/14023h/products/5e9eee7e2243a.png?w=550&auto=format", true);
            Product product2 = new Product(2, "Brun nalle",
                "Lorem ipsum dolor sit amet, con sectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                10, 0, "https://quickbutik.imgix.net/14023h/products/64fad0129d13d.jpeg?w=550&auto=format", false);
            Product product3 = new Product(3, "Gulbrun nalle",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec", 
                10, 5, "https://quickbutik.imgix.net/14023h/products/64ccb0448dddc.png?w=550&auto=format", false);
            Product product4 = new Product(4, "Beige nalle",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec", 
                10, 5, "https://quickbutik.imgix.net/14023h/products/64ca0aaf1c381.png?w=550&auto=format", false);
            Product product5 = new Product(5, "Vit nalle",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                10, 5, "https://quickbutik.imgix.net/14023h/products/64c912fb48822.png?w=550&auto=format",false);

            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
            Products.Add(product4);
            Products.Add(product5);
        }
        public List<Product> GetList() => Products;

        public Customer AddCustomer(string name, string password)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(password))
            {
                Customer customer = new Customer(id: CustomerList.Count + 1, username: name, password: password);
                CustomerList.Add(customer);
                return customer;
            }
            else
            {
                throw new ArgumentNullException("Either name or adress is null or empty.");
            }
        }
        public CustomerShopping AddCustomerShopping(string customerName, string customerPassword)
        {
            Customer newCustomer = new Customer(CustomerList.Count + 1, customerName, customerPassword);
            CustomerShopping customerShopping = new CustomerShopping(CustomerShoppingList.Count + 1, newCustomer, ShoppingList);
            CustomerShoppingList.Add(customerShopping);
            return customerShopping;
        }
    }
}