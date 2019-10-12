using System;
using System.Collections.Generic;
using System.Text;


namespace GTBusiness
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; private set; }
        public Provider _provider { get; private set; }
        public int SKU { get; private set; }


        public Product(string name, double value, string image)
        {
            Name = name;
            Price = value;
            Image = image;
        }
        public Product(string name, double value, string image, Provider provider)
        {
            Name = name;
            Price = value;
            Image = image;
            _provider = provider;
        }
    }
}
