using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Logout()
        {
            HttpCookieCollection MyCookieCollection = new HttpCookieCollection();
            Session.Remove("account");
            Session.Remove("listCart");
            HttpCookie username = new HttpCookie("username");
            HttpCookie password = new HttpCookie("username");

            username.Expires = DateTime.Now.AddDays(-1);
            password.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Add(username);
            Response.Cookies.Add(password);

            Response.Redirect("https://localhost:44394/Home/Index");

            return View();
        }
    }
}