using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Data.Models;

namespace WebShop.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set;}
    }
}
