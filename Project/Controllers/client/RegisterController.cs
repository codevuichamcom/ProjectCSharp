using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult signUp()
        {
            string warning = "";
            if (TempData["warning"] != null)
            {
                warning = TempData["warning"].ToString();
            }
            
            ViewData["warning"] = warning;
            return View();
        }
        [HttpPost]
        public ActionResult signUpProcess()
        {

            string userName = Request.Form["username"].ToString();
            string password = Request.Form["password"].ToString();

            string retypePassword = Request.Form["retypePassword"].ToString();
            string email = Request.Form["email"];
            string phone = Request.Form["phone"].ToString();
            bool isError = true;
            string warning = "";

            Account account = new AccountDao().getOne(userName);
            if (password!=retypePassword)
            {
                warning = "Password and RetypePassword is not the same";
                
            }
            else
            {
                if (account != null)
                {
                    warning = "Username is exist";
                }
                else 
                {
                    Account tempAcc = new AccountDao().getOneByEmail(email);
                    if (tempAcc != null)
                    {
                        warning = "Email is exist";
                    }
                    else
                    {
                        isError = false;
                    }
                }

                
            }
            if (isError)
            {
                TempData["warning"] = warning;
                //TempData["username"] = userName;
                //ViewData["password"] = password;
                //ViewData["retypePassword"] = retypePassword;
                //ViewData["email"] = email;
                //ViewData["phone"] = phone;
                return Redirect("https://localhost:44394/Register/signUp");
            }
            else
            {
                Account newAccount = new Account(userName, password, userName, "", email, phone, 4, 1, "", "");
                bool check = new AccountDao().insert(newAccount);
                if (!check)
                {
                    TempData["warning"] = "Sign up fail!";
                    return Redirect("https://localhost:44394/Register/signUp");
                }
                else
                {
                    return Redirect("https://localhost:44394/Login/login");
                }
                
            }
                
        }
    }
}