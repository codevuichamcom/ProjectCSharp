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
    public class AccountDao : BaseDAO<Account>
    {
        public override List<Account> getAll()
        {
            List<Account> list = new List<Account>();
            try
            {
                string sql = "SELECT * FROM Account";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Account a = new Account();
                    a.userName = Convert.ToString(reader["userName"]);
                    a.password = Convert.ToString(reader["password"]);
                    a.displayName= Convert.ToString(reader["displayName"]);
                    a.address= Convert.ToString(reader["address"]); ;
                    a.email= Convert.ToString(reader["email"]);
                    a.phone= Convert.ToString(reader["phone"]);
                    a.roleId= Convert.ToInt32(reader["role_id"]);
                    a.status= Convert.ToInt32(reader["status"]);
                    a.createDate= Convert.ToString(reader["create_date"]);
                    a.activeCode= Convert.ToString(reader["active_code"]);

                    list.Add(a);
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
        public int countAccount()
        {
            try
            {
                string sql = "SELECT COUNT(*) as count FROM Account";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader["count"]);
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
        public override Account getOne(int id)
        {
            throw new NotImplementedException();
        }
        public Account getOne(string username)
        {
            try
            {
                string sql = "SELECT * FROM Account WHERE userName = @username";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", username);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Account a = new Account();
                    a.userName = Convert.ToString(reader["userName"]);
                    a.password = Convert.ToString(reader["password"]);
                    a.displayName = Convert.ToString(reader["displayName"]);
                    a.address = Convert.ToString(reader["address"]); ;
                    a.email = Convert.ToString(reader["email"]);
                    a.phone = Convert.ToString(reader["phone"]);
                    a.roleId = Convert.ToInt32(reader["role_id"]);
                    a.status = Convert.ToInt32(reader["status"]);
                    a.createDate = Convert.ToString(reader["create_date"]);
                    a.activeCode = Convert.ToString(reader["active_code"]);

                    return a;
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

        public Account getOneAccount(string userName, string password)
        {
            try
            {
                string sql = "SELECT * FROM Account WHERE userName = @username and password = @password";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", userName);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Account a = new Account();
                    a.userName = Convert.ToString(reader["userName"]);
                    a.password = Convert.ToString(reader["password"]);
                    a.displayName = Convert.ToString(reader["displayName"]);
                    a.address = Convert.ToString(reader["address"]); ;
                    a.email = Convert.ToString(reader["email"]);
                    a.phone = Convert.ToString(reader["phone"]);
                    a.roleId = Convert.ToInt32(reader["role_id"]);
                    a.status = Convert.ToInt32(reader["status"]);
                    a.createDate = Convert.ToString(reader["create_date"]);
                    a.activeCode = Convert.ToString(reader["active_code"]);

                    return a;
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
        public Account getOneByEmail(string email)
        {
            try
            {
                string sql = "SELECT * FROM Account WHERE email = @email";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@email", email);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Account a = new Account();
                    a.userName = Convert.ToString(reader["userName"]);
                    a.password = Convert.ToString(reader["password"]);
                    a.displayName = Convert.ToString(reader["displayName"]);
                    a.address = Convert.ToString(reader["address"]); ;
                    a.email = Convert.ToString(reader["email"]);
                    a.phone = Convert.ToString(reader["phone"]);
                    a.roleId = Convert.ToInt32(reader["role_id"]);
                    a.status = Convert.ToInt32(reader["status"]);
                    a.createDate = Convert.ToString(reader["create_date"]);
                    a.activeCode = Convert.ToString(reader["active_code"]);

                    return a;
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
        public override bool insert(Account entity)
        {
            int check = 0;
            try { 
                string sql = @"INSERT INTO [dbo].[Account] "
                    + "           ([userName]\n"
                    + "           ,[password]\n"
                    + "           ,[displayName]\n"
                    + "           ,[address]\n"
                    + "           ,[email]\n"
                    + "           ,[phone]\n"
                    + "           ,[role_id]\n"
                    + "           ,[status])\n"
                    + "     VALUES\n"
                    + "           (@userName,@password,@displayName,@address,@email,@phone,@role_id,@status)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@userName", entity.userName);
                command.Parameters.AddWithValue("@password", entity.password);
                command.Parameters.AddWithValue("@displayName", entity.displayName);
                command.Parameters.AddWithValue("@address", entity.address);
                command.Parameters.AddWithValue("@email", entity.email);
                command.Parameters.AddWithValue("@phone", entity.phone);
                command.Parameters.AddWithValue("@role_id", entity.roleId);
                command.Parameters.AddWithValue("@status", entity.status);
                connection.Open();
                check= command.ExecuteNonQuery();
               
                connection.Close();
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
            return check >0;
}

        public bool update(Account entity, string username)
        {
            int check = 0;
            try
            {
                string sql = @"UPDATE [dbo].[Account]"
                + "   SET [displayName] = @displayName\n"
                + "      ,[address] = @address\n"
                + "      ,[email] = @email\n"
                + "      ,[phone] = @phone\n"
                + "      ,[role_id] = @role_id\n"
                + "      ,[status] = @status\n"
                + "      ,[password] = @password\n"
                + " WHERE userName =@userName";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@userName", username);
                command.Parameters.AddWithValue("@password", entity.password);
                command.Parameters.AddWithValue("@displayName", entity.displayName);
                command.Parameters.AddWithValue("@address", entity.address);
                command.Parameters.AddWithValue("@email", entity.email);
                command.Parameters.AddWithValue("@phone", entity.phone);
                command.Parameters.AddWithValue("@role_id", entity.roleId);
                command.Parameters.AddWithValue("@status", entity.status);
                connection.Open();
                check = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return check > 0;
        }

        public bool updateByAdmin(Account entity, string username)
        {
            int check = 0;
            try
            {
                string sql = @"UPDATE [dbo].[Account]"
                + "   SET [displayName] = @displayName\n"
                + "      ,[address] = @address\n"
                + "      ,[email] = @email\n"
                + "      ,[phone] = @phone\n"
                + "      ,[role_id] = @role_id\n"
                + "      ,[status] = @status\n"
                + " WHERE userName =@userName";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@userName", username);
                command.Parameters.AddWithValue("@displayName", entity.displayName);
                command.Parameters.AddWithValue("@address", entity.address);
                command.Parameters.AddWithValue("@email", entity.email);
                command.Parameters.AddWithValue("@phone", entity.phone);
                command.Parameters.AddWithValue("@role_id", entity.roleId);
                command.Parameters.AddWithValue("@status", entity.status);
                connection.Open();
                check = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return check > 0;
        }
        public bool updateStatus(String username, int status)
        {
            int check = 0;
            try
            {
                string sql = @"UPDATE dbo.Account\n"
                + "SET status = @status \n"
                + "WHERE userName=?";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@userName", username);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                check= command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return check>0;
        }
        public bool removebyUser(String username)
        {
            int check = 0;
            try
            {
                string sql = @"DELETE FROM dbo.Account WHERE userName = @userName";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@userName", username);
                connection.Open();
               check= command.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return check>0;
        }
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override bool update(Account entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}