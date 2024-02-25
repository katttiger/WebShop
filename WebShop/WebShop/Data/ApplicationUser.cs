using Microsoft.AspNetCore.Identity;
using WebShop.Common.Classes;
using WebShop.Data.Models;

namespace WebShop.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }

        //En shoppingcart/användare
        public ShoppingCart Shoppinglist { get;  }
    }
}
