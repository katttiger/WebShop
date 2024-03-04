using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.Http;
using WebShop.Data.Models;
using WebShop.Common.Classes;

namespace WebShop.Data
{
    public class WebShopHandler
    {
        public Products Products;
        public ApplicationUser applicationUser;
        public CartItem ShoppingCartItem;
        public List<CartItem> ShoppingCart = new();
        public List<Products> ProductList = new();
        public string currency = string.Empty;
        public NavigationManager navigationManager { get; set; }

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
                user.ShoppingCart = new();

            CartItem cartItem = new CartItem(Products, 1, Products.Id);
            if (ShoppingCart.Count() > 0)
            {
                var item = user.ShoppingCart.ShoppingList.Find(p => p.Product.Id == cartItem.Product.Id);
                if (item == null)
                    ShoppingCart.Add(cartItem);
                else
                {
                    user.ShoppingCart.ShoppingList.Find(i => i.Product.Id == cartItem.Product.Id).Quantity++;
                }
            }
            else
                ShoppingCart.Add(cartItem);

            Products.Quantity--;
            ShoppingCart = user.ShoppingCart.ShoppingList;
            _context.Update(user);
            _context.SaveChanges();
        }

        public void ConfirmPurchase()
        {
            foreach (var item in applicationUser.ShoppingCart.ShoppingList)
            {
                _context.CartItems.Remove(item);
            }
            ShoppingCart.Clear();
            applicationUser.ShoppingCart.ShoppingList = ShoppingCart;
            _context.SaveChanges();
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

        public async Task UpdateUser(ApplicationUser user)
        {
            _context.Update(user);
            applicationUser = user;
            _context.SaveChanges();
        }

        public async Task<ApplicationUser> GetUserShopinglistInfo(ApplicationUser user)
        {
            if (user.ShoppingCart is null)
            {
                var shoppingCart = new ShoppingCart();
                shoppingCart.User = user;
                shoppingCart.User.Id = user.Id;
                user.ShoppingCartId = shoppingCart.Id;
                var createdCart = _context.ShoppingCarts.Add(shoppingCart);
                user.ShoppingCartId = shoppingCart.Id;
                shoppingCart.Id = user.ShoppingCartId;
                _context.SaveChanges();
            }
            else if (user.ShoppingCart.ShoppingList == null || user.ShoppingCart.ShoppingList.Count() == 0)
            {
                user.ShoppingCart.ShoppingList = ShoppingCart;
                _context.SaveChanges();
            }
            //Fetches a list with null-values since they are not connected to a product.
            //Walks through the empty contructor in CartItem, then it return null
            var foundUser = _context.Users.Include(user => user.ShoppingCart.ShoppingList)
                .First(u => u.Id == user.Id);
            foreach (var item in foundUser.ShoppingCart.ShoppingList)
            {
                if (item.Product == null)
                {
                    ProductList = _context.Products.ToList();
                    var product = ProductList.Find(i => i.Id == item.ProductId);
                    if (product is not null)
                        foundUser.ShoppingCart.ShoppingList.Find(p => p.ProductId == product.Id).Product = product;
                }
            }
            applicationUser = foundUser;
            ShoppingCart = foundUser.ShoppingCart.ShoppingList;
            return foundUser;
        }
    }
}