using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double productPrice { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }

        public Order Order;

        public OrderDetail(int id, int orderId, int productId, int quantity, double productPrice, string productName, string productImage, Order order)
        {
            this.id = id;
            this.orderId = orderId;
            this.productId = productId;
            this.quantity = quantity;
            this.productPrice = productPrice;
            this.productName = productName;
            this.productImage = productImage;
            Order = order;
        }
        public OrderDetail()
        {
        }
    }
}