using System;
using System.Collections.Generic;
using System.Text;


namespace GTBusinessLayer
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; private set; }
        public Provider _provider { get; private set; }
        public int SKU { get; private set; }


        public Product(string name, double price, string image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
        public Product(string name, double price, string image, Provider provider)
        {
            Name = name;
            Price = price;
            Image = image;
            _provider = provider;
        }
    }
}
