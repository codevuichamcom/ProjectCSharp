using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using System.Data.SqlClient;
using System.Data;

namespace Project.DAL
{
    public class ImageDao : BaseDAO<Image>
    {
        
        public override List<Image> getAll()
        {
            throw new NotImplementedException();
        }

        public List<Image> getAllImageByProductId(int productId)
        {
            List<Image> list = new List<Image>();
            try
            {
                string sql = "SELECT * FROM dbo.Image WHERE product_id =@productId";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@productId", productId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                    Image image = new Image();
                    image.id = Convert.ToInt32(reader["id"]);
                    image.productId = Convert.ToInt32(reader["product_id"]);
                    image.imageName = Convert.ToString(reader["image_name"]);
                    image.status = Convert.ToInt32(reader["status"]); ;
                    list.Add(image);
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
        public override Image getOne(int id)
        {

            try
            {
                string sql = "SELECT * FROM Image WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Image i = new Image();
                    i.id = Convert.ToInt32(reader["id"]);
                    i.productId = Convert.ToInt32(reader["product_id"]);
                    i.imageName = reader["image_name"].ToString();
                    i.status = Convert.ToInt32(reader["status"]);
                    return i;
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

        public override bool insert(Image entity)
        {
            int check = 0;
            try
            {
                string sql = "INSERT INTO [dbo].[Image] ([product_id],[image_name],[status]) "
                + "VALUES(@productId,@imageName,@status)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@productId", entity.productId);
                cmd.Parameters.AddWithValue("@imageName", entity.imageName);
                cmd.Parameters.AddWithValue("@status", entity.status);
                connection.Open();
                check = cmd.ExecuteNonQuery();
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
            return check > 0;
        }

        public override bool update(Image entity, int id)
        {
            int check = 0;
            try
            {
                string sql = "UPDATE [dbo].[Image] SET [product_id] = @productId,[image_name] = @imageName,[status] = @status "
                + "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@productId", entity.productId);
                cmd.Parameters.AddWithValue("@imageName", entity.imageName);
                cmd.Parameters.AddWithValue("@status", entity.status);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                check = cmd.ExecuteNonQuery();
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
            return check > 0;
        }

        public bool UpdateListImage(List<Image> list, int productId)
        {
            int check = 0;
            try
            {
                string sql = @"UPDATE [dbo].[Image] SET [product_id] = ?,[image_name] = ?,[status] = ? "
                + "WHERE id=?";

                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                foreach (Image image in list)
                {
                    command.Parameters.AddWithValue("@product_id", image.productId);
                    command.Parameters.AddWithValue("@image_name", image.imageName);
                    command.Parameters.AddWithValue("@status", image.status);
                    command.Parameters.AddWithValue("@id", image.id);

                    check = command.ExecuteNonQuery();
                }
                transaction.Commit();

                //connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return check > 0;
        }

        public override bool delete(int id)
        {
            int check = 0;
            try
            {
                string sql = "DELETE FROM Image WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                check = cmd.ExecuteNonQuery();
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
            return check > 0;
        }
    }
}