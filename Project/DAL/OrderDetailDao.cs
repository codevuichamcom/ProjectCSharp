using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DAL;
using Project.Models;

namespace Project.DAL
{
    public class OrderDetailDao : BaseDAO<OrderDetail>
    {

        public bool add(List<Cart> list, int orderId)
        {
            int check = 0;
            //SqlTransaction transaction=null;
            try
            {
                string sql = @"INSERT INTO [dbo].[order_detail]
           ([order_id]
           ,[product_id]
           ,[product_name]
           ,[product_price]
           ,[quantity]
           ,[product_image])
     VALUES
           (@order_id,@product_id,@product_name,@product_price,@quantity,@product_image)";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();
                //transaction = connection.BeginTransaction();
                //command.Transaction = transaction;
                foreach (Cart c in list)
                {
                    command.Parameters.AddWithValue("@order_id", orderId);
                    command.Parameters.AddWithValue("@product_id", c.productId);
                    command.Parameters.AddWithValue("@product_name", c.productName);
                    command.Parameters.AddWithValue("@product_price", c.productPrice);
                    command.Parameters.AddWithValue("@quantity", c.quantity);
                    command.Parameters.AddWithValue("@product_image", c.productImg);
                    //add Batch
                    check = command.ExecuteNonQuery();
                }
                //transaction.Commit();

                connection.Close();
            }
            catch (SqlException ex)
            {
                //transaction.Rollback();
                //throw ex;
                
            }
            return check > 0;
        }

        public List<OrderDetail> getOrderDetailByOrderId(int orderId)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {
                string sql = "SELECT * FROM dbo.order_detail WHERE order_id =@order_id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@order_id", orderId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrderDetail od = new OrderDetail();
                    od.id = Convert.ToInt32(reader["id"]);
                    od.orderId = Convert.ToInt32(reader["order_id"]);
                    od.productId = Convert.ToInt32(reader["product_id"]);
                    od.productName = Convert.ToString(reader["product_name"]); ;
                    od.productPrice = Convert.ToDouble(reader["product_price"]);
                    od.quantity = Convert.ToInt32(reader["quantity"]);
                    od.productImage = Convert.ToString(reader["product_image"]);

                    list.Add(od);
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
        public List<OrderDetail> getAllOrderSuccess(String customer)
        {
            List<OrderDetail> list = new List<OrderDetail>();
            try
            {
                string sql = "SELECT dbo.order_detail.* FROM dbo.order_detail INNER JOIN dbo.[order] on dbo.[order].id=order_id WHERE status = 4 AND Customer=@customer";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@customer", customer);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Order order = new OrderDao().getOne(Convert.ToInt32(reader[1]));
                    OrderDetail od = new OrderDetail();
                    od.id = Convert.ToInt32(reader["id"]);
                    od.orderId = Convert.ToInt32(reader["order_id"]);
                    od.productId = Convert.ToInt32(reader["product_id"]);
                    od.productName = Convert.ToString(reader["product_name"]); ;
                    od.productPrice = Convert.ToDouble(reader["product_price"]);
                    od.quantity = Convert.ToInt32(reader["quantity"]);
                    od.productImage = Convert.ToString(reader["product_image"]);
                    od.Order = order;
                    list.Add(od);
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
        public override List<OrderDetail> getAll()
        {
            throw new NotImplementedException();
        }

        public override OrderDetail getOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool insert(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(OrderDetail entity, int id)
        {
            throw new NotImplementedException();
        }
        //removeByOrderId
        public override bool delete(int id)
        {
            int check = 0;
            try
            {
                string sql = @"DELETE dbo.order_detail WHERE order_id= @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
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
    }
}