using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class GetSubCategoryAdminController : Controller
    {
        // GET: GetSubCategoryAdmin
        public ActionResult GetSubCategoryAdmin()
        {
            List<SubCategory> listSubCategory = new SubCategoryDao().getAll();
            List<StatusProduct> listStatusProduct = new StatusProductDao().getAll();
            List<StatusCategory> listStatusCategory = new StatusCategoryDao().getAll();
            List<StatusSubCategory> listStatusSubCategory = new StatusSubCategoryDao().getAll();
            int numOfOrder = new OrderDao().countOrderWatting();

            ViewData["numOfOrder"] = numOfOrder;
            ViewData["listSubCategory"] = listSubCategory;
            ViewData["listStatusProduct"] = listStatusProduct;
            ViewData["listStatusCategory"] = listStatusCategory;
            ViewData["listStatusSubCategory"] = listStatusSubCategory;
            return View();
        }
    }
}