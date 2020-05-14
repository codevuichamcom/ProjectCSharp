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
    public class ViewDao: BaseDAO<View>
    {
        public int getView()
        {
            try
            {
                string sql = "SELECT * FROM [view]";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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
            return 0;
        }
        public  bool updateView(int count)
        {
            int check = 0;
            try
            {
                string sql = @"UPDATE [dbo].[view]
                            SET [view] = @view";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@view", count);
                connection.Open();
                check = cmd.ExecuteNonQuery();
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
            return check > 0;
        }
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<View> getAll()
        {
            throw new NotImplementedException();
        }

        public override View getOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool insert(View entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(View entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}