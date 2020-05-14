using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.DAL
{
    public class ShippingDao
    {
        public int addShippingReturnId(Shipping shipping)
        {

            //Change the connection string as per your design
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ConnectionString))
            {
                con.Open();
                //Insert QUery with Scope_Identity
                string sql = "INSERT INTO [dbo].[Shipping]\n"
                + "           ([name]\n"
                + "           ,[phone]\n"
                + "           ,[address])\n"
                + "     VALUES\n"
                + "           (@name,@phone,@address)";
                using (SqlCommand cmd = new SqlCommand(sql + "; SELECT SCOPE_IDENTITY()   ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    {
                        //Add parameter values
                        cmd.Parameters.AddWithValue("@name", shipping.name);
                        cmd.Parameters.AddWithValue("@phone", shipping.phone);
                        cmd.Parameters.AddWithValue("@address", shipping.address);
                        //Get the inserted query
                        int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                        return insertedID;
                    }
                }
            }
        }
        public int removeShippingReturnId(int id)
        {
            //Change the connection string as per your design
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ConnectionString))
            {
                con.Open();
                //Insert QUery with Scope_Identity
                string sql = "DELETE dbo.Shipping WHERE id =@id";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    {
                        //Add parameter values
                        cmd.Parameters.AddWithValue("@id", id);
                        //Get the inserted query
                        int insertedID =cmd.ExecuteNonQuery();
                        return id;
                    }
                }
            }
        }

    }
}