using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using GTData;


namespace GTBusinessLayer
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }

        public string Genre { get; set; }
        public string Description { get; private set; }
        public Brand Brand { get; private set; }
        public int SKU { get; set; }

        public Product()
        {

        }
        public Product(string name, double price, byte[] image)
        {
            Name = name;
            Price = price;
            Image = image;
        }
        public Product(string name, double price, byte[] image, Brand provider)
        {
            Name = name;
            Price = price;
            Image = image;
            Brand = provider;
        }
        public Product(string name, double price, byte[] image, Brand provider, string genre)
        {
            Name = name;
            Price = price;
            Image = image;
            Brand = provider;
            Genre = genre;
        }

        public List<Product> Listing()
        {
            //ProductRepo product = new ProductRepo();
            //return product.Retrieve();

            ProductRepo productRepo = new ProductRepo();
            List<Product> products;
            DataTable data = productRepo.RetrieveList();
            products = (from DataRow row in data.Rows
                    select new Product()
                    {
                        SKU = (int)row["product_id"],
                        Name = (string)row["full_name"],
                        Price = Convert.ToDouble(row["price"]),
                        Genre = (string)row["genre"],
                        Brand = new Brand((string)row["brand"]),
                        Description = (string)row["description"]
                    }).ToList();
            return products;
        }
        public DataTable ListingByGenre(string genre)
        {
            ProductRepo product = new ProductRepo();
            return product.Retrieve(genre);
        }
        public DataTable ListingByID(int id)
        {
            ProductRepo product = new ProductRepo();
            return product.RetrieveByID(id);
        }
    }
}
