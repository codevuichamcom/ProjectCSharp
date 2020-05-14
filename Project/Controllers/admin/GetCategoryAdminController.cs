using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class GetCategoryAdminController : Controller
    {
        // GET: CategoryAdmin
        public ActionResult CategoryAdmin()
        {
            List<Account> listAccount = new AccountDao().getAll();
            List<StatusAccount> listStatusAccount = new StatusAccountDao().getAll();
            List<RoleAccount> listRoleAccount = new RoleAccountDao().getAll();

            List<Product> listProduct = new ProductDao().getAll();
            List<Category> listCategory = new CategoryDao().getAll();
            List<SubCategory> listSubCategory = new SubCategoryDao().getAll();
            List<StatusProduct> listStatusProduct = new StatusProductDao().getAll();
            List<StatusCategory> listStatusCategory = new StatusCategoryDao().getAll();
            List<StatusSubCategory> listStatusSubCategory = new StatusSubCategoryDao().getAll();

            int numOfOrder = new OrderDao().countOrderWatting();

            ViewData["numOfOrder"] = numOfOrder;

            ViewData["listAccount"] = listAccount;
            ViewData["listStatusAccount"] = listStatusAccount;
            ViewData["listRoleAccount"] = listRoleAccount;
            ViewData["listProduct"] = listProduct;
            ViewData["listCategory"] = listCategory;
            ViewData["listSubCategory"] = listSubCategory;
            ViewData["listStatusProduct"] = listStatusProduct;
            ViewData["listStatusCategory"] = listStatusCategory;
            ViewData["listStatusSubCategory"] = listStatusSubCategory;
            return View();
        }

    }
}