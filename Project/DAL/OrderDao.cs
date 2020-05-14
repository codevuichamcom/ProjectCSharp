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
    public class OrderDao : BaseDAO<Order>
    {
      
        public override List<Order> getAll()
        {
            throw new NotImplementedException();
        }

        public override Order getOne(int id)
        {
            try
            {
                string sql = "SELECT * FROM dbo.[order] WHERE id= @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Order o = new Order();
                    o.id = Convert.ToInt32(reader["id"]);
                    o.customer = Convert.ToString(reader["Customer"]);
                    o.shippingId = Convert.ToInt32(reader["shipping_id"]);
                    o.createDate = Convert.ToString(reader["create_date"]);
                    o.totalPrice = Convert.ToDouble(reader["total_price"]);
                    o.note = Convert.ToString(reader["note"]);
                    o.status = Convert.ToInt32(reader["status"]);
                    return o;
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

        public override bool insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(Order entity, int id)
        {
            throw new NotImplementedException();
        }
        public override bool delete(int id)
        {
            int check = 0;
            try
            {
                string sql = @"DELETE dbo.[order] WHERE id =@id";

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
        public List<Order> getOrderByCustomer()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT * FROM dbo.[order] WHERE status = 2";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Order o = new Order();
                    o.id = Convert.ToInt32(reader["id"]);
                    o.customer = Convert.ToString(reader["Customer"]);
                    o.shippingId = Convert.ToInt32(reader["shipping_id"]);
                    o.createDate = Convert.ToString(reader["create_date"]);
                    o.totalPrice = Convert.ToDouble(reader["total_price"]);
                    o.note = Convert.ToString(reader["note"]);
                    o.status = Convert.ToInt32(reader["status"]);

                    orders.Add(o);
                    return orders;
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
        public int addOrderReturnId(Order order)
        {
            List<Order> orders = new List<Order>();
            try
            {
               


                //Change the connection string as per your design
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ConnectionString))
                {
                    con.Open();
                    //Insert QUery with Scope_Identity
                    string sql = "INSERT INTO dbo.[order]\n"
                + "          ( Customer ,\n"
                + "            shipping_id ,\n"
                + "            total_price ,\n"
                + "            note ,\n"
                + "            status\n"
                + "          )\n"
                + "  VALUES  (@Customer,@shipping_id,@total_price,@note,@status)";
                    using (SqlCommand cmd = new SqlCommand(sql + "; SELECT SCOPE_IDENTITY()   ", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        {
                            //Add parameter values
                            cmd.Parameters.AddWithValue("@Customer", order.customer);
                            cmd.Parameters.AddWithValue("@shipping_id", order.shippingId);
                            cmd.Parameters.AddWithValue("@total_price", order.totalPrice);
                            cmd.Parameters.AddWithValue("@note", order.note);
                            cmd.Parameters.AddWithValue("@status", order.status);
                            //Get the inserted query
                            int insertedID = Convert.ToInt32(cmd.ExecuteScalar());
                            return insertedID;
                        }
                    }
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

        public List<Order> getOrderNotSuccesYetByCustomer(string cus, int status)
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT dbo.[order].*,dbo.Shipping.name,dbo.Shipping.phone,dbo.Shipping.address,status_order.status \n"
                + "  FROM dbo.[order] INNER JOIN dbo.Shipping\n"
                + "  ON Shipping.id = [order].shipping_id INNER JOIN status_order\n"
                + "  ON status_order.code = dbo.[order].status WHERE Customer =@cus AND dbo.[order].status <> @status";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cus", cus);
                command.Parameters.AddWithValue("@status", status);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Shipping shipping = new Shipping();
                    shipping.id = Convert.ToInt32(reader["shipping_id"]);
                    shipping.name = Convert.ToString(reader["name"]);
                    shipping.phone = Convert.ToString(reader["phone"]);
                    shipping.address = Convert.ToString(reader["address"]);

                    StatusOrder statusOrder = new StatusOrder();
                    statusOrder.code = Convert.ToInt32(reader[6]);
                    statusOrder.status = Convert.ToString(reader[10]);

                    Order o = new Order();
                    o.id = Convert.ToInt32(reader["id"]);
                    o.customer = Convert.ToString(reader["Customer"]);
                    o.shippingId = Convert.ToInt32(reader["shipping_id"]);
                    o.createDate = Convert.ToString(reader["create_date"]);
                    o.totalPrice = Convert.ToDouble(reader["total_price"]);
                    o.note = Convert.ToString(reader["note"]);
                    o.status = Convert.ToInt32(reader["status"]);
                    o.Shipping = shipping;
                    o.statusOrder = statusOrder;

                    orders.Add(o);
                    
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
            return orders;
        }
        public List<Order> getAllOrderNotAcceptYet()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT dbo.[order].*,dbo.Shipping.name,dbo.Shipping.phone,dbo.Shipping.address,status_order.status \n"
                + "  FROM dbo.[order] INNER JOIN dbo.Shipping\n"
                + "  ON Shipping.id = [order].shipping_id INNER JOIN status_order\n"
                + "  ON status_order.code = dbo.[order].status WHERE dbo.[order].status =1";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Shipping shipping = new Shipping();
                    shipping.id = Convert.ToInt32(reader["shipping_id"]);
                    shipping.name = Convert.ToString(reader["name"]);
                    shipping.phone = Convert.ToString(reader["phone"]);
                    shipping.address = Convert.ToString(reader["address"]);

                    StatusOrder statusOrder = new StatusOrder();
                    statusOrder.code = Convert.ToInt32(reader[6]);
                    statusOrder.status = Convert.ToString(reader[10]);

                    Order o = new Order();
                    o.id = Convert.ToInt32(reader["id"]);
                    o.customer = Convert.ToString(reader["Customer"]);
                    o.shippingId = Convert.ToInt32(reader["shipping_id"]);
                    o.createDate = Convert.ToString(reader["create_date"]);
                    o.totalPrice = Convert.ToDouble(reader["total_price"]);
                    o.note = Convert.ToString(reader["note"]);
                    o.status = Convert.ToInt32(reader["status"]);
                    o.Shipping = shipping;
                    o.statusOrder = statusOrder;

                    orders.Add(o);
                    
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
            return orders;
        }
        public List<Order> getAllOrderShipping()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT dbo.[order].*,dbo.Shipping.name,dbo.Shipping.phone,dbo.Shipping.address,status_order.status \n"
                + "  FROM dbo.[order] INNER JOIN dbo.Shipping\n"
                + "  ON Shipping.id = [order].shipping_id INNER JOIN status_order\n"
                + "  ON status_order.code = dbo.[order].status WHERE dbo.[order].status =3";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Shipping shipping = new Shipping();
                    shipping.id = Convert.ToInt32(reader["shipping_id"]);
                    shipping.name = Convert.ToString(reader["name"]);
                    shipping.phone = Convert.ToString(reader["phone"]);
                    shipping.address = Convert.ToString(reader["address"]);

                    StatusOrder statusOrder = new StatusOrder();
                    statusOrder.code = Convert.ToInt32(reader[6]);
                    statusOrder.status = Convert.ToString(reader[10]);

                    Order o = new Order();
                    o.id = Convert.ToInt32(reader["id"]);
                    o.customer = Convert.ToString(reader["Customer"]);
                    o.shippingId = Convert.ToInt32(reader["shipping_id"]);
                    o.createDate = Convert.ToString(reader["create_date"]);
                    o.totalPrice = Convert.ToDouble(reader["total_price"]);
                    o.note = Convert.ToString(reader["note"]);
                    o.status = Convert.ToInt32(reader["status"]);
                    o.Shipping = shipping;
                    o.statusOrder = statusOrder;

                    orders.Add(o);
                    
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
            return orders;
        }
        public List<Order> getAllSucces()
        {
            List<Order> orders = new List<Order>();
            try
            {
                string sql = "SELECT dbo.[order].*,dbo.Shipping.name,dbo.Shipping.phone,dbo.Shipping.address,status_order.status \n"
                + "  FROM dbo.[order] INNER JOIN dbo.Shipping\n"
                + "  ON Shipping.id = [order].shipping_id INNER JOIN status_order\n"
                + "  ON status_order.code = dbo.[order].status WHERE dbo.[order].status =4";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Shipping shipping = new Shipping();
                    shipping.id = Convert.ToInt32(reader["shipping_id"]);
                    shipping.name = Convert.ToString(reader["name"]);
                    shipping.phone = Convert.ToString(reader["phone"]);
                    shipping.address = Convert.ToString(reader["address"]);

                    StatusOrder statusOrder = new StatusOrder();
                    statusOrder.code = Convert.ToInt32(reader[6]);
                    statusOrder.status = Convert.ToString(reader[10]);

                    Order o = new Order();
                    o.id = Convert.ToInt32(reader["id"]);
                    o.customer = Convert.ToString(reader["Customer"]);
                    o.shippingId = Convert.ToInt32(reader["shipping_id"]);
                    o.createDate = Convert.ToString(reader["create_date"]);
                    o.totalPrice = Convert.ToDouble(reader["total_price"]);
                    o.note = Convert.ToString(reader["note"]);
                    o.status = Convert.ToInt32(reader["status"]);
                    o.Shipping = shipping;
                    o.statusOrder = statusOrder;

                    orders.Add(o);
                    
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
            return orders;
        }
        public int countOrderWatting()
        {
            try
            {
                string sql = "SELECT COUNT(*) as count\n"
                + "FROM dbo.[order] INNER JOIN dbo.Shipping\n"
                + "ON Shipping.id = [order].shipping_id INNER JOIN status_order\n"
                + "ON status_order.code = dbo.[order].status WHERE dbo.[order].status = 1";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

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
        public int removeOrderByShippingIdReturnId(int shipping_id)
        {
          
            //Change the connection string as per your design
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HouseWareShopConnectionString"].ConnectionString))
            {
                con.Open();
                //Insert QUery with Scope_Identity
                string sql = "DELETE dbo.[order] WHERE id =@id";
                using (SqlCommand cmd = new SqlCommand(sql + "; SELECT SCOPE_IDENTITY()   ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    {
                        //Add parameter values
                        cmd.Parameters.AddWithValue("@id", shipping_id);
                        //Get the inserted query
                        cmd.ExecuteNonQuery();
                        return shipping_id;
                    }
                }
            }
        }
        public bool updateStatus(int status, int id)
        {
            int check = 0;
            try
            {
                string sql = @"UPDATE dbo.[order] SET status=@status WHERE id = @id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@status", status);
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
        public double calRevenueInMonth(int month)
        {
            try
            {
                string sql = "SELECT ISNULL(SUM(total_price),'0')AS total FROM dbo.[order] WHERE YEAR(create_date)=YEAR(GETDATE()) and MONTH(create_date)=@month";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@month", month);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["total"]);
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
    }
}