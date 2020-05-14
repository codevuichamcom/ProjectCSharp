using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Image
    {
        public Image()
        {
        }

        public Image(int id, int productId, string imageName, int status)
        {
            this.id = id;
            this.productId = productId;
            this.imageName = imageName;
            this.status = status;
        }

        public int id { get; set; }
        public int productId { get; set; }
        public string imageName { get; set; }
        public int status { get; set; }
    }
}