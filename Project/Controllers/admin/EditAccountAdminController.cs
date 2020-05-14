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
    public class EditAccountAdminController : Controller
    {
        // GET: EditAccountAdmin
        public ActionResult EditAccount()
        {
            string userName = Request.QueryString["user"];
            Account accountEdit = new AccountDao().getOne(userName);
            //List<Account> listAccount = new AccountDao().getAll();
            //List<StatusAccount> listStatusAccount = new StatusAccountDao().getAll();

            List<RoleAccount> listRoleAccount = new RoleAccountDao().getAll();
            TempData["accountEdit"] = accountEdit;
            //ViewData["listAccount"] = listAccount;
            //ViewData["listStatusAccount"] = listStatusAccount;
            //ViewData["listRoleAccount"] = listRoleAccount;

            //request.getRequestDispatcher("admin/Account.jsp").forward(request, response);

            return Redirect("~/GetAccountAdmin/GetAccountAdmin");
        }

        [HttpPost]
        public ActionResult EditAccountPost()
        {

            string username = Request.Form["username"];
            string displayName = Request.Form["displayName"];
            string address = Request.Form["address"];
            string email = Request.Form["email"];
            string phone = Request.Form["phone"];
            int status = NumberHelper.getInt(Request.Form["status"]);
            int role = NumberHelper.getInt(Request.Form["role"]);

            Account accountOld = new AccountDao().getOne(username);
            Account AccountCheckEmail = new AccountDao().getOneByEmail(email);
            if (AccountCheckEmail != null && !AccountCheckEmail.userName.Equals(accountOld.userName))
            {
                ViewData["error"] = "Email is exist";
                ViewData["message"] = "Please go to dashboard and put onother email";
                //request.getRequestDispatcher("admin/ErrorAdmin.jsp").forward(request, response);
            }
            else
            {
                Account accountNew = new Account(username, displayName, email, phone, address, role, status);

                bool check = new AccountDao().updateByAdmin(accountNew, username);
                if (!check)
                {
                    ViewData["error"] = "Update Failed!";
                    ViewData["message"] = "Please go to dashboard and try again!";
                    //request.getRequestDispatcher("admin/ErrorAdmin.jsp").forward(request, response);
                }
                else
                {
                    //response.sendRedirect("get-accounts");
                    Response.Redirect("~/GetAccountAdmin/GetAccountAdmin");
                }
            }
            return View();
        }
    }
}