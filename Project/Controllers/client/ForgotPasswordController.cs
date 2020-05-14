using Project.DAL;
using Project.Models;
using System;
using System.Web.Mvc;

namespace Project.Controllers.client
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult ForgotPassword()
        {
            if (TempData["warning"] != null)
            {
                ViewData["warning"] = TempData["warning"].ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPasswordPost()
        {
            string username = Request.Form["username"];
            string to = Request.Form["email"];

            String warning = "";

            Account account = new AccountDao().getOne(username);

            if (account != null)
            {
                if (to.Equals(account.email))
                {
                    string subject = "Password Recovery ";
                    string body = "";
                    body += " <html>";
                    body += "<body>";
                    body += "<table>";

                    body += "<tr>";
                    body += "<td>User Name : </td><td>"+ account.userName +"</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<td>Password : </td><td>"+account.password+"</td>";
                    body += "</tr>";

                    body += "</table>";
                    body += "</body>";
                    body += "</html>";

                    Ultilities.SendMail.Send(to, subject, body);
                    return Redirect("~/Login/login");
                }
                else
                {
                    warning = "Email is incorrect";
                    TempData["warning"] = warning;
                    return Redirect("~/ForgotPassword/ForgotPassword");
                }
            }
            else
            {
                warning = "Account not found";
                TempData["warning"] = warning;
                return Redirect("~/ForgotPassword/ForgotPassword");
            }
            return View();
        }
    }
}