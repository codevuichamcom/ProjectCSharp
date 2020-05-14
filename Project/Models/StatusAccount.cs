using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class StatusAccount
    {
        public StatusAccount()
        {
        }

        public StatusAccount(int code, string status)
        {

            this.code = code;
            this.status = status;
        }


        public int code { get; set; }
        public string status { get; set; }
    }
}