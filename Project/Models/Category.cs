using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Category
    {
        public Category(int id, string category, int status, List<SubCategory> listSubCategory)
        {
            this.id = id;
            this.category = category;
            this.status = status;
            this.listSubCategory = listSubCategory;
        }
        public Category(string category, int status)
        {
            this.category = category;
            this.status = status;
        }
        public Category()
        {
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        public StatusCategory getStatus(int id)
        {
            string sql = "SELECT * FROM dbo.status_category WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", this.status);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                StatusCategory statusCategory = new StatusCategory();
                statusCategory.id = Convert.ToInt32(reader["id"]);
                statusCategory.code = Convert.ToInt32(reader["code"]);
                statusCategory.status = Convert.ToString(reader["status"]);
                return statusCategory;
            }

            return null;
        }
        public int id { get; set; }
        public string category { get; set; }
        public int status { get; set; }
        public List<SubCategory> listSubCategory { get; set; }

    }
}