using Project.DAL;
using Project.Models;
using Project.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class AcceptOrderAdminController : Controller
    {
        // GET: AcceptOrderAdmin
        public ActionResult AcceptOrderAdmin()
        {
            int id = NumberHelper.getInt(Request.QueryString["id"]);
            bool check = new OrderDao().updateStatus(2, id);
            if (check)
            {

                string username = new OrderDao().getOne(id).customer;
                Account account = new AccountDao().getOne(username);
                string subject = "Your order has been  Accepted.";
                string body = "";
                body += " <html>";
                body += "<body>";
                body += "<h3>Your order has been  Accepted.</h3>";
                body += "<h3>Thank you very much!</h3>";
                body += "<h3>Please confirm your order when you receive your order.</h3>";
                body += "</body>";
                body += "</html>";

                Ultilities.SendMail.Send(account.email, subject, body);

                Response.Redirect("~/ProcessOrderAdmin/ProcessOrderAdmin?check=2");
            }
            else
            {
                // response.getWriter().println("Accept failed!");
            }
            return View();
        }
    }
}