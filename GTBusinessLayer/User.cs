using System;
using System.Collections.Generic;
using System.Text;

namespace GTBusinessLayer
{
    public class User
    {
        Profile profile;
        public User()
        {
            profile = new Visitor();
        }
        public User(Profile profile)
        {
            this.profile = profile;
        }
        public void SetProfile(Profile profile)
        {
            this.profile = profile;
        }

        public string GetRole()
        {
            return this.profile.GetRole();
        }

        public override string ToString()
        {
            string reg = "Visitor";
            reg = profile.GetRole().Equals(reg) ? "NO" : "SI";
            return $"Registrado:{reg}";
        }

    }
}
