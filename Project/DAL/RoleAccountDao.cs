using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;
using Project.Models;

namespace Project.DAL
{
    public class RoleAccountDao : BaseDAO<RoleAccount>
    {
        

        public override List<RoleAccount> getAll()
        {
            List<RoleAccount> list = new List<RoleAccount>();
            try
            {
                string sql = "SELECT * FROM role_account";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RoleAccount ra = new RoleAccount();
                    ra.code = Convert.ToInt32(reader["code"]);
                    ra.role = Convert.ToString(reader["role"]);
                    list.Add(ra);
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

        public override RoleAccount getOne(int id)
        {
            try
            {
                string sql = "SELECT * FROM dbo.role_Account WHERE code = @id";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RoleAccount ra = new RoleAccount();
                    ra.code = Convert.ToInt32(reader["code"]);
                    ra.role = Convert.ToString(reader["role"]);
                    return ra;
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

        public override bool insert(RoleAccount entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(RoleAccount entity, int id)
        {
            throw new NotImplementedException();
        }
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}