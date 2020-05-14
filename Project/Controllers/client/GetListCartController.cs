using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class GetListCartController : Controller
    {
        // GET: GetListCart
        public ActionResult Cart()
        {
           
            List<Category> listCategory = new CategoryDao().getAll();
            ViewData["listCategory"] = listCategory;
            Session["url"] = "https://localhost:44394/GetListCart/Cart";

            return View();
        }
    }
}