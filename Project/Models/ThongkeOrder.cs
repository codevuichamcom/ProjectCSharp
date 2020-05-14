using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class ThongkeOrder
    {
        public ThongkeOrder(){}
        public ThongkeOrder(int day, string thu, int numOfOrder, double totalMoney)
        {
            this.day = day;
            this.thu = thu;
            this.numOfOrder = numOfOrder;
            this.totalMoney = totalMoney;
        }

        public int day { get; set; }
        public string thu { get; set; }
        public int numOfOrder { get; set; }
        public double totalMoney { get; set; }
    }
}