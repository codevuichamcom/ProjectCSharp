using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.client
{
    public class ChangeProfileController : Controller
    {
        // GET: ChangeProfile

        [HttpPost]
        public ActionResult ChangePost()
        {
            string message = "";
            string displayName = Request.Form["displayName"];
            string password = Request.Form["password"];
            string retypePassword = Request.Form["retypePassword"];
            string email = Request.Form["email"];

            string phone = Request.Form["phone"];
            string address = Request.Form["address"];

            Account a = (Account)Session["account"];
            Account accountOld = new AccountDao().getOne(a.userName);
            if (displayName.Trim().Equals(""))
            {
                displayName = accountOld.displayName;
            }
            if (!password.Equals(retypePassword))
            {
                message = "Password and re-type not the same.";
                TempData["message"] = message;
                return Redirect("~/MyProfile/MyProfile");
            }
            if (password.Equals(""))
            {
                password = accountOld.password;
            }
            if (email.Trim().Equals(""))
            {
                email = accountOld.email;
            }
            if (phone.Trim().Equals(""))
            {
                phone = accountOld.phone;
            }
            if (address.Trim().Equals(""))
            {
                address = accountOld.address;
            }
            Account accountNew = new Account();accountNew.userName = a.userName;
            accountNew.password = password;
            accountNew.displayName = displayName;
            accountNew.email = email;accountNew.phone = phone;
            accountNew.address = address;
            accountNew.roleId = accountOld.roleId;
            accountNew.status= accountOld.status;
            Session["account"] = accountNew;

            bool check = new AccountDao().update(accountNew, a.userName);
            if (check)
            {
                message = "Updated sucessfull";
                TempData["message"] = message;
                return Redirect("~/MyProfile/MyProfile");
            }
            else
            {
                message = "Updated Failed!";
                TempData["message"] = message;
                return Redirect("~/MyProfile/MyProfile");
            }

        }
    }
}