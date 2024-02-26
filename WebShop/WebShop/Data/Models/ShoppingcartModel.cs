using Common.Interface;
using Microsoft.AspNetCore.Http.Metadata;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Common.Classes;

namespace WebShop.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<Products> ShoppingList { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
