using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class WebShopHandler
    {
        public Products Products = new();
        public ApplicationUser applicationUser;

        public List<Products> ShoppingCart = new();
        public List<Products> ProductList = new();
        

        public bool error = false;
        public string errorMessage = string.Empty;
        private const string apiKey = "oSZAPBiQWuTEFVLaXLzrkQ==SCNxLNPoxMs72JLy";

        //Have a list with shoppinglist.
        //Store that list in local storage? or database (not possible)       
        public NavigationManager navigationManager { get; set; }

        private readonly ApplicationDbContext _context;
        public WebShopHandler(ApplicationDbContext context) => _context = context;

        //Fetch products
        public List<Products> GetAllProducts() => _context.Products.ToList();
        public Products GetProductsById(int id)
        {
            foreach (var product in _context.Products)
            {
                if (product.Id == id)
                {
                    Products = product;
                }
                else
                    continue;
            }
            return Products;
        }
        //Add to cart
        public void AddToCart(int id)
        {
            //If the item already exists, do no add it to the cart.

            Products = GetProductsById(id);
            foreach (var product in ShoppingCart)
            {
                if (ShoppingCart.Contains(product))
                    break;
            }
            ShoppingCart.Add(Products);
            Products.Quantity--;
        }
        public void ConfirmPurchase(bool purchaseConfirmed)
        {
            if (purchaseConfirmed)
            {
                _context.ShoppingCarts.Where(p => p.IsCompleted == true);
                _context.Products.Update(Products);
                ShoppingCart.Clear();
            }
        }

        //public List<Products> GetAllItemsBought()
        //{
        //    _context.ShoppingCarts.Add(new ShoppingCart
        //    {
        //        User = applicationUser,
        //        IsCompleted = false,
        //        ShoppingList = ShoppingCart
        //    });
        //    return ShoppingCart;
        //}

        //User related methods
        public async Task Seed()
        {
            _context.Add(new Products
            {

                Name = "Grå nalle",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                Price = 10,
                Quantity = 5,
                IsOnSale = true,
                Url = "https://quickbutik.imgix.net/14023h/products/5e9eee7e2243a.png?w=550&auto=format"
            });
            _context.Add(new Products
            {

                Name = "Brun nalle",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                Price = 10,
                Quantity = 0,
                IsOnSale = false,
                Url = "https://quickbutik.imgix.net/14023h/products/64fad0129d13d.jpeg?w=550&auto=format"
            });
            _context.Add(new Products
            {

                Name = "Gulbrun nalle",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                Price = 10,
                Quantity = 6,
                IsOnSale = false,
                Url = "https://quickbutik.imgix.net/14023h/products/64ccb0448dddc.png?w=550&auto=format"
            });
            _context.Add(new Products
            {

                Name = "Beige nalle",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                Price = 10,
                Quantity = 4,
                IsOnSale = false,
                Url = "https://quickbutik.imgix.net/14023h/products/64ca0aaf1c381.png?w=550&auto=format"
            });
            _context.Add(new Products
            {

                Name = "Vit nalle",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nunc magna,scelerisque non dolor nec",
                Price = 10,
                Quantity = 2,
                IsOnSale = false,
                Url = "https://quickbutik.imgix.net/14023h/products/64c912fb48822.png?w=550&auto=format"
            });
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(ApplicationUser user)
        {
            applicationUser = user;
            _context.Update(user);
            _context.SaveChanges();
        }
        public async Task<ApplicationUser> GetUserShopinglistInfo(ApplicationUser user) => _context.Users.Include(u => u.ShoppingCart).First(u => u.Id == user.Id);
    }
}

/*
 COLLECTIONDATA
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


 */




