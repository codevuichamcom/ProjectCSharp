using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id, int categoryId, string code, string name, int quantity, double price, string description, string image, string createDate, int status, int subCategoryId, List<Image> listImage, double sale)
        {
            this.id = id;
            this.categoryId = categoryId;
            this.code = code;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.description = description;
            this.image = image;
            this.createDate = createDate;
            this.status = status;
            this.subCategoryId = subCategoryId;
            this.listImage = listImage;
            this.sale = sale;
        }

        public int id { get; set; }
        public int categoryId { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string createDate { get; set; }
        public int status { get; set; }
        public int subCategoryId { get; set; }
        public List<Image> listImage { get; set; }
        public double sale { get; set; }
    }
}