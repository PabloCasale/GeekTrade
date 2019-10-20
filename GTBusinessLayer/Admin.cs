using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBusinessLayer
{
    public class Admin : Profile
    {
        public override string GetRole()
        {
            return "Admin";
        }
    }
}
