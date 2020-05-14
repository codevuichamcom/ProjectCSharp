using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Account
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        public Account(string userName, string password, string displayName, string address, string email, string phone, int roleId, int status, string createDate, string activeCode)
        {
            this.userName = userName;
            this.password = password;
            this.displayName = displayName;
            this.address = address;
            this.email = email;
            this.phone = phone;
            this.roleId = roleId;
            this.status = status;
            this.createDate = createDate;
            this.activeCode = activeCode;
        }
        /// 
        /// ->>>>>>>>>>>>> con to rac to 2 tham so

        public Account(string userName, string password, string displayName, string address, string email, string phone, int roleId, int status)
        {
            this.userName = userName;
            this.password = password;
            this.displayName = displayName;
            this.address = address;
            this.email = email;
            this.phone = phone;
            this.roleId = roleId;
            this.status = status;
        }

        public Account(string username, string displayName, string email, string phone, string address, int roleId, int status)
        {

            this.userName = userName;
            this.displayName = displayName;
            this.address = address;
            this.email = email;
            this.phone = phone;
            this.roleId = roleId;
            this.status = status;

        }

        

        public Account()
        {
          
        }
        public string userName { get; set; }
        public string password { get; set; }
        public string displayName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int roleId { get; set; }
        public int status { get; set; }
        public string createDate { get; set; }
        public string activeCode { get; set; }

        public RoleAccount getRole(int id)
        {
            try
            {
                string sql = "SELECT * FROM dbo.role_Account WHERE code = @roleId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@roleId", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    RoleAccount roleAccount = new RoleAccount();
                    roleAccount.code = Convert.ToInt32(reader["code"]);
                    roleAccount.role = Convert.ToString(reader["role"]);
                    return roleAccount;
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

        public StatusAccount getStatus(int id)
        {
            try
            {
                String sql = "SELECT * FROM dbo.status_Account WHERE code =@code";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@code", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusAccount statusAccount = new StatusAccount();
                    statusAccount.code = Convert.ToInt32(reader["code"]);
                    statusAccount.status = Convert.ToString(reader["status"]);
                    return statusAccount;
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