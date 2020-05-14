using Project.DAL;
using Project.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class DeleteOrderAdminController : Controller
    {
        // GET: DeleteOrderAdmin
        public ActionResult DeleteOrderAdmin()
        {
            int id = NumberHelper.getInt(Request.QueryString["id"]);
            bool check = new OrderDetailDao().delete(id);

            bool check2 = new OrderDao().delete(id);

            int flag = NumberHelper.getInt(Request.QueryString["flag"]);
            if (flag == 1)
            {
                Response.Redirect("~/MyProfile/MyProfile");
            }
            else
            {
                Response.Redirect("~/ProcessOrderAdmin/ProcessOrderAdmin?check=2");
            }
            

            return View();
        }
    }
}