using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Common.Classes;

namespace WebShop.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<CartItem> ShoppingList { get; set; } = new();
        

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
