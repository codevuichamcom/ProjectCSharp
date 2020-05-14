using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class SubCategory
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        public SubCategory(){}
        public SubCategory(int id, int categoryId, string subCategoryName, int status)
        {
            this.id = id;
            this.categoryId = categoryId;
            this.subCategoryName = subCategoryName;
            this.status = status;
        }
        public SubCategory(int categoryId, string subCategoryName, int status)
        {
            this.categoryId = categoryId;
            this.subCategoryName = subCategoryName;
            this.status = status;
        }
        public int id { get; set; }
        public int categoryId { get; set; }
        public string subCategoryName { get; set; }
        public int status { get; set; }

        //THÊM 2 HÀM
        public Category getCategory(int id)
        {
            try
            {
                string sql = "SELECT * FROM Category WHERE id = " + this.categoryId;
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Category category = new Category();
                    category.id = Convert.ToInt32(reader[0]);
                    category.category = Convert.ToString(reader[1]);
                    category.status = Convert.ToInt32(reader[2]);
                    return category;
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
            return null;
        }

        public StatusSubCategory getStatus(int id)
        {
            try
            {
                String sql = "SELECT * FROM dbo.status_category WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusSubCategory statusSubCategory = new StatusSubCategory();
                    statusSubCategory.id = Convert.ToInt32(reader[0]);
                    statusSubCategory.code = Convert.ToInt32(reader[1]);
                    statusSubCategory.status = Convert.ToString(reader[2]);
                    return statusSubCategory;
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
            return null;
        }
    }
}