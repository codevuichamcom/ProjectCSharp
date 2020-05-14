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
    public class SubCategoryDao : BaseDAO<SubCategory>
    {
        public override List<SubCategory> getAll()
        {
            List<SubCategory> list = new List<SubCategory>();
            try
            {
                string sql = "SELECT * FROM dbo.sub_category";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SubCategory sub = new SubCategory();
                    sub.id = Convert.ToInt32(reader["id"]);
                    sub.categoryId = Convert.ToInt32(reader["category_id"]);
                    sub.subCategoryName = Convert.ToString(reader["sub_category_name"]);
                    sub.status = Convert.ToInt32(reader["status"]);
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

        public List<SubCategory> getAllByCategoryId(int categoryId)
        {
            List<SubCategory> list = new List<SubCategory>();
            try
            {
                string sql = "SELECT * FROM dbo.sub_category WHERE category_id = @categoryId";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SubCategory sub = new SubCategory();
                    sub.id = Convert.ToInt32(reader["id"]);
                    sub.categoryId = Convert.ToInt32(reader["category_id"]);
                    sub.subCategoryName = Convert.ToString(reader["sub_category_name"]);
                    sub.status = Convert.ToInt32(reader["status"]);
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

        public override SubCategory getOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool insert(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(SubCategory entity, int id)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }
        public int countSubCategory()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM dbo.sub_category";
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
    }
}