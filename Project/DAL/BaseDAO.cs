using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class BaseDAO<T>
    {
        internal SqlConnection connection;
        public BaseDAO()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public abstract List<T> getAll();
        public abstract T getOne(int id);
        public abstract bool insert(T entity);
        public abstract bool update(T entity, int id);
        public abstract bool delete(int id);
    }
}
