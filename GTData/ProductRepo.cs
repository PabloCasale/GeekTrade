using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            var query = db.ReadByCommand("select * from Products");
            
            return query;
        }

        public DataTable Retrieve(string genre)
        {

            Connection db = new Connection();
            return db.ReadByCommand($"select * from Products where genre = '{genre}' ");
        }

        public DataTable RetrieveByID(int id)
        {

            Connection db = new Connection();
            return db.ReadByCommand($"select * from Products where product_id = {id} ");
        }



        public DataTable RetrieveList()
        {
            Connection db = new Connection();
            return db.ReadByCommand($"select * from Products");
        }

        public int UpdateTable(int id, string name, string genre, string brand, decimal price)
        {
            Connection db = new Connection();
            var query = db.WriteByCommand($"update products set full_name = '{name}', price = {price} where product_id = {id}");
            
            return query;
        }

        public bool Save()
        {
            return true;
        }
    }
}
