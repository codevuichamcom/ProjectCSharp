using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult checkout()
        {

            Account account = (Account)Session["account"];
            if (account == null)
            {
                Response.Redirect("https://localhost:44394/Login/Login");
            }
            else
            {
                List<Category> listCategory = new CategoryDao().getAll();
                ViewData["listCategory"] = listCategory;
                Session["url"] = "https://localhost:44394/CheckOut/checkout";
                return View();
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult CheckOutPost()
        {
            string name = Request.Form["name"];
            string mobile = Request.Form["mobile"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];
            Shipping shipping = new Shipping(name, mobile, address);
            List<Category> listCategory = new CategoryDao().getAll();
            TempData["listCategory"] = listCategory;
            TempData["note"] = note;
            TempData["shipping"] = shipping;
            return Redirect("~/PrepareShipping/PrepareShipping");
        }
    }
}