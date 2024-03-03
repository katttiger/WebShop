namespace WebShop.Client.ClientModels
{
    public class ClientCartItems
    {
        public ClientProducts Products { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
