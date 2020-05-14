using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Project.Models;
using System.Data;
using System.Data.SqlClient;
namespace Project.DAL
{
    public class StatusCategoryDao : BaseDAO<StatusCategory>
    {
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<StatusCategory> getAll()
        {
            List<StatusCategory> list = new List<StatusCategory>();
            try
            {
                string sql = "SELECT * FROM dbo.status_category";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusCategory sub = new StatusCategory();
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

        public override StatusCategory getOne(int id)
        {
            StatusCategory statusCategory = new StatusCategory();
            try
            {
                string sql = "SELECT * FROM status_category WHERE id =@id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    statusCategory.id = Convert.ToInt32(reader["id"]);
                    statusCategory.code = Convert.ToInt32(reader["code"]);
                    statusCategory.status = Convert.ToString(reader["status"]);
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
            return statusCategory;
        }

        public override bool insert(StatusCategory entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(StatusCategory entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}