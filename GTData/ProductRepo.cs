using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTData
{
    public class ProductRepo
    {
        public DataTable Retrieve()
        {
            
            Connection db = new Connection();


            return db.ReadByCommand("select * from Products");
        }

        public List<DataTable> RetrieveList()
        {
            return new List<DataTable>();
        }

        public bool Save()
        {
            return true;
        }
    }
}
