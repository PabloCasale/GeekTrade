using System;
using System.Collections.Generic;
using System.Text;

namespace GTBusinessLayer
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }
        public string Password { get; set; }

        public bool Registered { get; set; }

        public override string ToString()
        {
            var reg = Registered ? "SI" : "NO";
            return $"Usuario:{ID} Nombre:{Name} Registrado:{reg}";
        }

    }
}
