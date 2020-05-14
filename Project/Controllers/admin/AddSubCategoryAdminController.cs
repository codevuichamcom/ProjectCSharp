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
    public class AddSubCategoryAdminController : Controller
    {
        // GET: AddSubCategoryAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCategoryAdmin()
        {
            string name = Request.Form["username"];
            int category = NumberHelper.getInt(Request.Form["category"]);
            int status = NumberHelper.getInt(Request.Form["status"]);

            SubCategory subCategory = new SubCategory(category, name, status);

            bool check = new SubCategoryDao().insert(subCategory);
            if (check)
            {
                //response.sendRedirect("get-sub-category");
                Response.Redirect("https://localhost:44394/GetSubCategoryAdmin/GetSubCategoryAdmin");
            }
            else
            {
                ViewData["error"] = "Add Sub Category Failed!";
                ViewData["message"] = "Please go to dashboard and try again!";

                //todo
                //Response.Redirect("https://localhost:44394/admin/ErrorAdmin.jsp");
                
            }
            return View();
        }
    }
}