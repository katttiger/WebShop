namespace WebShop.Client.ClientModels
{
    public class ClientCartItems
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int QuantityBought { get; set; }
        public string Url { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
