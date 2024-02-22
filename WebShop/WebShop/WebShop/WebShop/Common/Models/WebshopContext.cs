using Microsoft.EntityFrameworkCore;
using WebShop.Client.Pages;
using WebShop.Common.Classes;

namespace WebShop.Common.Context
{
    public class WebshopContext : DbContext
    {
        public WebshopContext(DbContextOptions<WebshopContext> options) : base(options) { }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<CustomerModel> Customers { get; set; }

        public DbSet<CustomerShoppingModel> CustomersShopping { get; set; }
    }
}
