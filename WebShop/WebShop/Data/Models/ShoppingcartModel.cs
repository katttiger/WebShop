using Common.Interface;
using Microsoft.AspNetCore.Http.Metadata;
using WebShop.Common.Classes;

namespace WebShop.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Url { get; set; }
        public List<Product>? Shoppinglist { get; set; } = new();
        //En shoppingcartlista/användare
        public ApplicationUser User { get; set; }
    }
}
