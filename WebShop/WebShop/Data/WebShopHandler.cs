using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using WebShop.Common.Classes;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class WebShopHandler
    {
        public Products Products;
        public ApplicationUser applicationUser;

        public List<Products> ShoppingCart = new();
        public List<Products> ProductList = new();
        public NavigationManager navigationManager { get; set; }

        public bool error = false;
        public string errorMessage = string.Empty;

        public ExchagneConverter converter;
        private readonly ApplicationDbContext _context;
        public WebShopHandler(ApplicationDbContext context) => _context = context;

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

        public void AddToCart(int id, ApplicationUser user)
        {
            Products = GetProductsById(id);
            if (user.ShoppingCart is null)
            {
                user.ShoppingCart = new();
            }
            //Fix index
            user.ShoppingCart.ShoppingList.Add(Products);
            ShoppingCart = user.ShoppingCart.ShoppingList;
            Products.Quantity--;
            _context.Users.Update(user);
            _context.SaveChanges();
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


        public void Exchange()
        {
            string a = "USD";
            string b = "EUR";
            converter.Method(b, a);
        }
        public async Task UpdateUser(ApplicationUser user)
        {
            applicationUser = user;
            _context.Update(user);
            applicationUser = user;
            _context.SaveChanges();
        }

        public async Task<ApplicationUser> GetUserShopinglistInfo(ApplicationUser user)
        {
            //Problem: The cart is reset when we log out of the application.
            if (user.ShoppingCart is null)
            {
                var shoppingCart = new ShoppingCart();
                shoppingCart.User = user;
                var createdCart = _context.ShoppingCarts.Add(shoppingCart);
                user.ShoppingCartId = shoppingCart.Id;
                _context.SaveChanges();
            }
            var foundUser = _context.Users.Include(user => user.ShoppingCart).ThenInclude(cart => cart.ShoppingList).First(u => u.Id == user.Id);
            applicationUser = foundUser;
            return foundUser;
        }
    }
}

