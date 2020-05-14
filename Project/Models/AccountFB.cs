using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class AccountFB
    {
        public AccountFB(string id, string displayName, string createDate, int roleId, int status)
        {
            this.id = id;
            this.displayName = displayName;
            this.createDate = createDate;
            this.roleId = roleId;
            this.status = status;
        }
        public AccountFB()
        {

        }
        public string id { get; set; }
        public string displayName { get; set; }
        public string createDate { get; set; }
        public int roleId { get; set; }
        public int status { get; set; }
    }
}