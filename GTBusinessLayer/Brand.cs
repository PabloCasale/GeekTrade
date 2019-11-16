using System;
using System.Collections.Generic;
using System.Text;

namespace GTBusinessLayer
{
    public class Brand
    {
        public string name { get; private set; }

        public Brand(string brand)
        {
            name = brand;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
