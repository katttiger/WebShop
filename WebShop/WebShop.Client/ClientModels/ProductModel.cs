<<<<<<<< HEAD:WebShop/WebShop.Client/ClientModels/ClientProducts.cs
﻿namespace WebShop.Client.ClientModels
========
﻿using Common.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Common.Classes;

namespace WebShop.Data.Models
>>>>>>>> 88c2ad6a7d6d5ad9bfca303d76b2ebed46f88b9a:WebShop/WebShop.Client/ClientModels/ProductModel.cs
{
    public class ClientProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; } = 10;
        public int Quantity { get; set; }
        public bool IsOnSale { get; set; }
        public string Url { get; set; }

<<<<<<<< HEAD:WebShop/WebShop.Client/ClientModels/ClientProducts.cs
        public ClientCartItems CartItem { get; set; }
========
        public CartItem CartItem { get; set; }
>>>>>>>> 88c2ad6a7d6d5ad9bfca303d76b2ebed46f88b9a:WebShop/WebShop.Client/ClientModels/ProductModel.cs
    }
}
