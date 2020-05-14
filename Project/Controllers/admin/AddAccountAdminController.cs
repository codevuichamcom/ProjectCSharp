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
    public class AddAccountAdminController : Controller
    {
        // GET: AddAccountAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAccountPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string displayName = Request.Form["displayName"];
            string address = Request.Form["address"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            int status = NumberHelper.getInt(Request.Form["status"]);
            int role = NumberHelper.getInt(Request.Form["role"]);

            Account accountOld = new AccountDao().getOne(username);
            if (accountOld != null)
            {
                ViewData["error"] = "Account is exist";
                ViewData["message"] = "Please go to dashboard and try again!";

                //todo
                Response.Redirect("https://localhost:44394/Home/admin/ErrorAdmin.jsp");
            }
            else
            {
                Account accountCheckEmail = new AccountDao().getOneByEmail(email);
                if (accountCheckEmail != null && !accountCheckEmail.userName.Equals(accountOld.userName))
                {
                    ViewData["error"] = "Email is exist";
                    ViewData["message"] = "Please go to dashboard and put onother email!";
                    //todo
                    Response.Redirect("https://localhost:44394/Home/admin/ErrorAdmin.jsp");
                }
                else
                {
                    Account accountNew = new Account(username, password, displayName, address, email, phone, role, status);


                    bool check = new AccountDao().insert(accountNew);
                    if (!check)
                    {
                        ViewData["error"] = "Add Account Failed!";
                        ViewData["message"] = "Please go to dashboard and try again!";

                        //todo
                        Response.Redirect("https://localhost:44394/Home/admin/ErrorAdmin.jsp");
                    }
                    else
                    {
                        // response.sendRedirect("get-accounts");
                        Response.Redirect("https://localhost:44394/GetAccountAdmin/GetAccountAdmin");
                    }
                }
            }
            return View();
        }
    }
}