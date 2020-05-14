using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class RoleAccount
    {
        public RoleAccount()
        {
        }

        public RoleAccount(int code, string role)
        {
            this.code = code;
            this.role = role;
        }

        public int code { get; set; } 
        public string role { get; set; }
    }
}