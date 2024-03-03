namespace WebShop.Client.ClientModels
{
    public class ClientShoppingCart
    {
        public int Id { get; set; }
        public List<ClientCartItems> ShoppingList { get; set; } = new();
    }
}
