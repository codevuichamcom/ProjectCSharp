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
    public class AddCategoryAdminController : Controller
    {
        // GET: AddCategoryAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategoryAdmin()
        {
            string name = Request.Form["username"];
            int status = NumberHelper.getInt(Request.Form["status"]);

            Category category = new Category(name, status);

            bool check = new CategoryDao().insert(category);
            if (check)
            {
                //response.sendRedirect("get-categories");
                Response.Redirect("https://localhost:44394/GetCategoryAdmin/GetCategoryAdmin");
            }
            else
            {
                ViewData["error"] = "Add Category Failed!";
                ViewData["message"] = "Please go to dashboard and try again!";
                //to do
                Response.Redirect("https://localhost:44394/Home/admin/ErrorAdmin.jsp");
            }
            return View();
        }
    }
}