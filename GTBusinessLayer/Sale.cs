using System;
using System.Collections.Generic;
using System.Text;

namespace GTBusinessLayer
{
    public class Sale
    {
        public int ID { get; private set; }
        public SalesDetail Detail { get; private set; }
        public Profile Seller { get; private set; }
        public Profile Buyer { get; private set; }


        public Sale(SalesDetail detail,Profile seller, Profile buyer)
        {
            Detail = detail;
            Seller = seller;
            Buyer = buyer;
        }

        public string GetSeller()
        {
            return Seller.Name;
        }

        public string GetBuyer()
        {
            return Buyer.Name;
        }



    }
}
