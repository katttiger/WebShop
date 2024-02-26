using Common.Interface;
using Microsoft.AspNetCore.Http.Metadata;
using WebShop.Common.Classes;

namespace WebShop.Data.Models
{
    public class ShoppingCart : IProduct
    {
        //Id
        //Id customer
        //Key to customer (tie list to customer)
        //Incorporate the list somehow

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsOnSale { get; set; }
        public string Url { get; set; }

        public ApplicationUser User { get; set; }
        
    }
}
