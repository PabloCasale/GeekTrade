using System;
using System.Collections.Generic;
using System.Text;

namespace GTBusiness
{
    public class SalesDetail
    {
        public Product _product { get; private set; }
        public double TotalPrice { get; private set; }
        public int TotalItems { get; private set; }


        public SalesDetail(Product product, int amount)
        {
            _product = product;
            TotalItems = amount;
            TotalPrice = amount * product.Price;
            
        }

        
    }
}
