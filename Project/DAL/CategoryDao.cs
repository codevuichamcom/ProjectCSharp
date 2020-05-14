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
    public class CategoryDao : BaseDAO<Category>
    {
        public override List<Category> getAll()
        {
            List<Category> list = new List<Category>();
            try
            {
                string sql = "SELECT * FROM Category";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<SubCategory> listSub = new SubCategoryDao().getAllByCategoryId(Convert.ToInt32(reader["id"]));
                    Category c = new Category();
                    c.id = Convert.ToInt32(reader["id"]);
                    c.category = Convert.ToString(reader["category"]);
                    c.status = Convert.ToInt32(reader["status"]);
                    c.listSubCategory = listSub;
                    list.Add(c);
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

        public override Category getOne(int id)
        {
            throw new NotImplementedException();
        }


        public override bool insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(Category entity, int id)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}