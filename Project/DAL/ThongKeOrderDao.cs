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
    public class ThongKeOrderDao : BaseDAO<ThongkeOrder>
    {
        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<ThongkeOrder> getAll()
        {
            List<ThongkeOrder> list = new List<ThongkeOrder>();
            try
            {
                string sql = @"select distinct DATENAME(dw,T.create_date) AS [weekday],T.subday , T.totalMoney,
	T.create_date, count(T.create_date) as numOfOrder
	from 
	(SELECT create_date, DATEDIFF(day, GETDATE(), create_date) as subday , T2.totalMoney
	FROM [order],
		( SELECT create_date as cdate,SUM(total_price) AS totalMoney FROM  [order]
		Group by create_date)T2 
	WHERE DATEDIFF(day, GETDATE(), create_date)>= -7 and DATEDIFF(day, GETDATE(), create_date) <= 0
	and create_date= T2.cdate)T
	group by T.create_date,T.subday , T.totalMoney";
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ThongkeOrder p = new ThongkeOrder();
                    p.day = Math.Abs(Convert.ToInt32(reader["subDay"]));
                    p.numOfOrder = Convert.ToInt32(reader["numOfOrder"]);
                    p.thu = Convert.ToString(reader["weekday"]);
                    p.totalMoney = Convert.ToDouble(reader["totalMoney"]);
               
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

        public override ThongkeOrder getOne(int id)
        {
            throw new NotImplementedException();
        }

        public override bool insert(ThongkeOrder entity)
        {
            throw new NotImplementedException();
        }

        public override bool update(ThongkeOrder entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}