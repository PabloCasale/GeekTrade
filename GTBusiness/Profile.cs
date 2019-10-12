using System;
using System.Collections.Generic;
using System.Text;

namespace GTBusiness
{
    public class Profile:User
    {
        public Profile(string name,string email)
        {
            this.Name = name;
            this.Email = email;
        }


        public string GetName()
        {
            return this.Name;
        }

        public string GetEmail()
        {
            return this.Email;
        }

    }
}
