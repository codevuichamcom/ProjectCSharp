using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Shipping
    {
        public Shipping()
        {
        }

        public Shipping(int id, string name, string phone, string address)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.address = address;
        }

        public Shipping(string name, string phone, string address)
        {
            this.name = name;
            this.phone = phone;
            this.address = address;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
}