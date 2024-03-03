using Common.Interface;

namespace Common.Classes
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{get; set;}
        public double Price { get; set; }
        public string Url { get; set; }
    }
}
