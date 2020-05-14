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
    public class StatusSubCategoryDao : BaseDAO<StatusSubCategory>
    {
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<StatusSubCategory> getAll()
        {
            List<StatusSubCategory> list = new List<StatusSubCategory>();
            try
            {
                string sql = "SELECT * FROM dbo.status_sub_category";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusSubCategory sub = new StatusSubCategory();
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

        public override StatusSubCategory getOne(int id)
        {
            StatusSubCategory statusSub = new StatusSubCategory();
            try
            {
                string sql = "SELECT * FROM dbo.status_sub_category WHERE id =@id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    statusSub.id = Convert.ToInt32(reader["id"]);
                    statusSub.code = Convert.ToInt32(reader["code"]);
                    statusSub.status = Convert.ToString(reader["status"]);
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
            return statusSub;
        }

        public override bool insert(StatusSubCategory entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(StatusSubCategory entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}