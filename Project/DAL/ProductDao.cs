using DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.DAL
{
    public class ProductDao : BaseDAO<Product>
    {
        public override List<Product> getAll()
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT * FROM dbo.product";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    list.Add(p);
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

        public List<Product> getAllPaging(int pageindex, int pagesize)
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT * FROM \n"
                + "(SELECT *,ROW_NUMBER() OVER (ORDER BY ID ASC) as row_num FROM  dbo.product) AS product\n"
                + "WHERE row_num >= (@pageindex - 1)*@pagesize +1 AND row_num<= @pageindex * @pagesize";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@pageindex", pageindex);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<Image> listImage = new ImageDao().getAllImageByProductId(Convert.ToInt32(reader["id"]));
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    p.listImage = listImage;

                    Image image = new Image();
                    image.productId = p.id;
                    image.imageName = p.image;
                    image.status = 1;
                    p.listImage.Insert(0, image);
                    list.Add(p);
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

        public int countPage()
        {
            try
            {
                string sql = "SELECT COUNT(*) as rownum FROM Product";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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
            return -1;
        }

        public List<Product> getAllByCategoryId(int categoryId)
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT * FROM product where category_id=@categoryId";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    list.Add(p);
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

        public List<Product> getAllByCategoryIdPaging(int categoryId, int pageindex, int pagesize)
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT * FROM\n"
                + "(SELECT *,ROW_NUMBER() OVER (ORDER BY ID ASC) as row_num FROM  product where category_id=@categoryId)AS product\n"
                + "WHERE row_num >= (@pageindex - 1)*@pagesize +1 AND row_num<= @pageindex * @pagesize";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@pageindex", pageindex);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    list.Add(p);
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

        //getAllBySubCategoryIdPaging
        public List<Product> getAllBySubCategoryIdPaging(int categoryId, int pageindex, int pagesize)
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT * FROM\n"
                + "(SELECT *,ROW_NUMBER() OVER (ORDER BY ID ASC) as row_num FROM  product where sub_category_id=@categoryId)AS product\n"
                + "WHERE row_num >= (@pageindex - 1)*@pagesize +1 AND row_num<= @pageindex * @pagesize";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@categoryId", categoryId);
                cmd.Parameters.AddWithValue("@pageindex", pageindex);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    list.Add(p);
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

        public List<Product> sortByDateDesc()
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT Top(4)* FROM dbo.product ORDER BY create_date DESC";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    list.Add(p);
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

        public override Product getOne(int id)
        {
            try
            {
                string sql = "SELECT * FROM product WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    List<Image> listImage = new ImageDao().getAllImageByProductId(Convert.ToInt32(reader["id"]));
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    p.listImage = listImage;

                    Image image = new Image();
                    image.productId = p.id;
                    image.imageName = p.image;
                    image.status = 1;
                    p.listImage.Insert(0, image);
                    return p;
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
            return null ;

        }

        public override bool insert(Product entity)
        {
            int check = 0;
            try
            {
                string sql = "INSERT INTO product(category_id, code, name, quantity, price,"
                + " description, image, status, sub_category_id)"
                + " VALUES(@categoryId, @code, @name, @quantity, @price, @description, @image, @status,@subCategoryId)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@categoryId", entity.categoryId);
                cmd.Parameters.AddWithValue("@code", entity.code);
                cmd.Parameters.AddWithValue("@name", entity.name);
                cmd.Parameters.AddWithValue("@quantity", entity.quantity);
                cmd.Parameters.AddWithValue("@price", entity.price);
                cmd.Parameters.AddWithValue("@description", entity.description);
                cmd.Parameters.AddWithValue("@image", entity.image);
                cmd.Parameters.AddWithValue("@status", entity.status);
                cmd.Parameters.AddWithValue("@subCategoryId", entity.subCategoryId);
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
            return check>0;
        }

        public override bool update(Product entity, int id)
        {
            int check = 0;
            try
            {
                string sql = "UPDATE product SET category_id = @categoryId, code = @code, name = @name,"
                + "quantity = @quantity, price = @price, description = @description, image = @image,"
                + "status = @status, sub_category_id = @subCategoryId WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@categoryId", entity.categoryId);
                cmd.Parameters.AddWithValue("@code", entity.code);
                cmd.Parameters.AddWithValue("@name", entity.name);
                cmd.Parameters.AddWithValue("@quantity", entity.quantity);
                cmd.Parameters.AddWithValue("@price", entity.price);
                cmd.Parameters.AddWithValue("@description", entity.description);
                cmd.Parameters.AddWithValue("@image", entity.image);
                cmd.Parameters.AddWithValue("@status", entity.status);
                cmd.Parameters.AddWithValue("@subCategoryId", entity.subCategoryId);
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

        public override bool delete(int id)
        {
            int check = 0;
            try
            {
                string sql = "DELETE FROM product WHERE id = @id";
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
        public int countPageByCategory(int id)
        {
            try
            {
                string sql = "SELECT COUNT(*) as rownum FROM Product where category_id=@id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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
            return -1;
        }

        //countPageByCategory
        public int countPageBySubCategory(int id)
        {
            try
            {
                string sql = "SELECT COUNT(*) as rownum FROM Product where sub_category_id=@id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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
            return -1;
        }

        public List<Product> search(string text, int pageindex, int pagesize)
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = @"SELECT * FROM "
                + "(SELECT *,ROW_NUMBER() OVER (ORDER BY ID ASC) as row_num \n"
                + "FROM dbo.product WHERE name LIKE @text OR description like @text) AS product \n"
                + "WHERE row_num >= (@pageindex - 1)*@pagesize +1 AND row_num<= @pageindex * @pagesize";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@text", "%"+text+"%");
                cmd.Parameters.AddWithValue("@pageindex", pageindex);
                cmd.Parameters.AddWithValue("@pagesize", pagesize);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);
                    list.Add(p);
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
        public int countProductWhenSearch(string text)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM dbo.product WHERE name LIKE @text OR description LIKE @text";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@text", "%"+text+"%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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
            return -1;
        }
        public int countProduct()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM dbo.product";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
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
        public List<int> countProductGroupByCategoryId()
        {
            List<int> list = new List<int>();
            try
            {
                string sql = @"SELECT COUNT(*) FROM dbo.product GROUP BY category_id ORDER BY category_id asc";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(Convert.ToInt32(reader[0]));
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
        public List<Product> getAllProductAreSaling()
        {
            List<Product> list = new List<Product>();
            try
            {
                string sql = "SELECT * FROM dbo.product WHERE status=2";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p = new Product();
                    p.id = Convert.ToInt32(reader["id"]);
                    p.categoryId = Convert.ToInt32(reader["category_id"]);
                    p.code = Convert.ToString(reader["code"]);
                    p.name = Convert.ToString(reader["name"]);
                    p.quantity = Convert.ToInt32(reader["quantity"]);
                    p.price = Convert.ToDouble(reader["price"]);
                    p.description = Convert.ToString(reader["description"]);
                    p.image = Convert.ToString(reader["image"]);
                    p.createDate = Convert.ToString(reader["create_date"]);
                    p.status = Convert.ToInt32(reader["status"]);
                    p.subCategoryId = Convert.ToInt32(reader["sub_category_id"]);
                    p.sale = Convert.ToDouble(reader["sale"]);

                    list.Add(p);
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
    }
}