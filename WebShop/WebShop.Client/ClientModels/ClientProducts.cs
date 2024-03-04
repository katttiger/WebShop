namespace WebShop.Client.ClientModels
{
    public class ClientProducts
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } = 10;
        public int Quantity { get; set; }
        public bool IsOnSale { get; set; }
        public string Url { get; set; }
    }
}
