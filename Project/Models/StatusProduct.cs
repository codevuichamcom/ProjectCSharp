using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class StatusProduct
    {
        public StatusProduct() {}
        public StatusProduct(int id, int code, string status)
        {
            this.id = id;
            this.code = code;
            this.status = status;
        }

        public int id { get; set; }
        public int code { get; set; }
        public string status { get; set; }
    }
}