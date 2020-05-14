using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Cart
    {
        public Cart(int productId, string productName, string productImg, double productPrice, int productQuantity, int quantity, double totalPrice)
        {
            this.productId = productId;
            this.productName = productName;
            this.productImg = productImg;
            this.productPrice = productPrice;
            this.productQuantity = productQuantity;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
        }
        public Cart()
        {

        }
        public int productId { get; set; }
        public string productName { get; set; }
        public string productImg { get; set; }
        public double productPrice { get; set; }
        public int productQuantity { get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }
    
}
}