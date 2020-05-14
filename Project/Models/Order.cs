using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Order
    {
        public int id { get; set; }
        public string customer { get; set; }
        public int shippingId { get; set; }
        public string createDate { get; set; }
        public double totalPrice { get; set; }
        public string note { get; set; }
        public int status { get; set; }

        public Shipping Shipping;

        public StatusOrder statusOrder;

        public Order(int id, string customer, int shippingId, string createDate, double totalPrice, string note, int status, Shipping shipping, StatusOrder statusOrder)
        {
            this.id = id;
            this.customer = customer;
            this.shippingId = shippingId;
            this.createDate = createDate;
            this.totalPrice = totalPrice;
            this.note = note;
            this.status = status;
            Shipping = shipping;
            this.statusOrder = statusOrder;
        }
        public Order()
        {
        }
    }
}