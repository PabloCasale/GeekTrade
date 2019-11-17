using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace GTData
{
    public class UsersRepo
    {
        public bool RetrieveRegistered(string email, string pass)
        {
            Connection db = new Connection();
            var query = db.ReadByCommand($"select * from Users Where email = '{email}' and password = HASHBYTES('SHA1','{pass}')");
            if (query.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
