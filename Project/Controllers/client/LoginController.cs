using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            string warning = "";
            Account account = (Account)Session["account"];

            if (account != null)
            {
                Response.Redirect("https://localhost:44394/Home/Index");
            }
            else
            {
                if (TempData["warning"] != null)
                {
                    warning = TempData["warning"].ToString();
                }

            }
            ViewData["warning"] = warning;
            return View();
        }
        [HttpPost]
        public ActionResult LoginPost()
        {
            string username = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();
            string remember = Request.Form["remember"];
            Account account = new AccountDao().getOneAccount(username, password);
            if (account != null)
            {
                Session["account"] = account;
                if (account.status == 3)
                {
                    TempData["warning"] = "You do not have access to this website";
                    Session["account"] = null;
                    Response.Redirect("~/Login/Login");
                }
                if (account.roleId == 1)
                {
                    Session["account"] = account;
                    Response.Redirect("~/ManagerAdmin/ManagerAdmin");
                }
                return Redirect("https://localhost:44394/Home/Index");
            }
            else
            {
                Session["account"] = account;
                TempData["warning"] = "Username or password incorrect";
                return Redirect("https://localhost:44394/Login/Login");
            }

        }
    }
}