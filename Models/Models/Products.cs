using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityLeft { get; set; }

        public Products(int id, string name, double price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityLeft = quantity;
        }
    }
}
