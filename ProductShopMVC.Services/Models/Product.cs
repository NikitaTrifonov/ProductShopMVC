﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShopMVC.Services.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        
        public Product (int id, string name, string price)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
        }
    }
}
