using Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class DeleteAccountAdminController : Controller
    {
        // GET: DeleteAccountAdmin
        public ActionResult DeleteAccount()
        {
            string username = Request.QueryString["user"];
            new AccountDao().removebyUser(username);
            // response.sendRedirect("get-accounts");
            Response.Redirect("~/GetAccountAdmin/GetAccountAdmin");
            return View();
        }
    }
}