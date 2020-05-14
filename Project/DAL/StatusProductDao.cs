using DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.DAL
{
    public class StatusProductDao : BaseDAO<StatusProduct>
    {
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<StatusProduct> getAll()
        {

            List<StatusProduct> list = new List<StatusProduct>();
            try
            {
                string sql = "SELECT * FROM dbo.status_product";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusProduct sub = new StatusProduct();
                    sub.id = Convert.ToInt32(reader["id"]);
                    sub.code = Convert.ToInt32(reader["code"]);
                    sub.status = Convert.ToString(reader["status"]);
                    list.Add(sub);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return list;
        }

        public override StatusProduct getOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool insert(StatusProduct entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(StatusProduct entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}