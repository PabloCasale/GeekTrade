using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GTData;


namespace GTBusinessLayer
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; private set; }
        public Provider _provider { get; private set; }
        public int SKU { get; private set; }

        public Product()
        {

        }
        public Product(string name, double price, byte[] image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
        public Product(string name, double price, byte[] image, Provider provider)
        {
            Name = name;
            Price = price;
            Image = image;
            _provider = provider;
        }

        public DataTable Listing()
        {
            ProductRepo product = new ProductRepo();
            return product.Retrieve();
        }
    }
}
