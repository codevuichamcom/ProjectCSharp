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
    public class StatusAccountDao : BaseDAO<StatusAccount>
    {
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<StatusAccount> getAll()
        {
            List<StatusAccount> list = new List<StatusAccount>();
            try
            {
                string sql = "SELECT * FROM dbo.status_Account";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StatusAccount sub = new StatusAccount();
                    //sub.id = Convert.ToInt32(reader["id"]);
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

        public override StatusAccount getOne(int id)
        {
            StatusAccount statusAccount = new StatusAccount();
            try
            {
                string sql = "SELECT * FROM dbo.status_Account WHERE code =@code";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@code", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //statusAccount.id = Convert.ToInt32(reader["id"]);
                    statusAccount.code = Convert.ToInt32(reader["code"]);
                    statusAccount.status = Convert.ToString(reader["status"]);
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
            return statusAccount;
        }

        public override bool insert(StatusAccount entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(StatusAccount entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}