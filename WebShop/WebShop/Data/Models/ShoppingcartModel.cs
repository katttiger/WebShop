using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public List<Products> ShoppingList = new();

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }



    }
}
