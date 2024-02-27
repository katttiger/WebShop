using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public List<Products> ShoppingList { get; set; }
        public bool IsCompleted { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
