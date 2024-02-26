using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //NOTE: Update shoppingcarts
        //REUIRED: Customer-relation, registration of all products etc.
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
    }
}
