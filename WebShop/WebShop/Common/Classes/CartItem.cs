using WebShop.Data.Models;

namespace WebShop.Common.Classes
{
    public class CartItem
    {
        public int id { get; set; }
        public Products Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public CartItem(Products product, int quantity, int productId) => (Product, Quantity, ProductId) = (product, quantity, productId);
        public CartItem() { }
    }
}
