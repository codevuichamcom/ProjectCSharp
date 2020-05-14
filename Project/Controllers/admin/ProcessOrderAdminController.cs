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
    public class ProcessOrderAdminController : Controller
    {
        // GET: ProcessOrderAdmin
        public ActionResult ProcessOrderAdmin()
        {
            Account account = (Account)Session["account"];
            List<Product> listProduct = new ProductDao().getAll();
            List<Category> listCategory = new CategoryDao().getAll();
            List<SubCategory> listSubCategory = new SubCategoryDao().getAll();
            List<StatusProduct> listStatusProduct = new StatusProductDao().getAll();
            List<StatusCategory> listStatusCategory = new StatusCategoryDao().getAll();
            List<StatusSubCategory> listStatusSubCategory = new StatusSubCategoryDao().getAll();
            List<StatusAccount> listStatusAccount = new StatusAccountDao().getAll();
            int check = NumberHelper.getInt(Request.QueryString["check"]);
            List<Order> listOrderWatting = null;
            if (check == 0)
            {
                listOrderWatting = new OrderDao().getAllSucces();
            }
            else
            {
                if (check == 1)
                {
                    listOrderWatting = new OrderDao().getAllOrderShipping();
                }
                else
                {
                    listOrderWatting = new OrderDao().getAllOrderNotAcceptYet();
                }
            }

            int numOfOrder = new OrderDao().countOrderWatting();

            ViewData["check"] = check;
            ViewData["numOfOrder"] = numOfOrder;
            ViewData["listOrderWatting"] = listOrderWatting;
            ViewData["listProduct"] = listProduct;
            ViewData["listCategory"] = listCategory;
            ViewData["listSubCategory"] = listSubCategory;
            ViewData["listStatusProduct"] = listStatusProduct;
            ViewData["listStatusCategory"] = listStatusCategory;
            ViewData["listStatusSubCategory"] = listStatusSubCategory;
            ViewData["listStatusAccount"] = listStatusSubCategory;

            return View();
        }
    }
}