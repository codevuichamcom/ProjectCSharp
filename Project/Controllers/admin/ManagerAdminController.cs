using Project.DAL;
using Project.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class ManagerAdminController : Controller
    {
        // GET: Manager
        public ActionResult ManagerAdmin()
        {
            Account account = (Account)Session["account"];

            if (account != null)
            {
                List<Account> listAccounts = new AccountDao().getAll();
                int check = 0;
                foreach (Account A in listAccounts)
                {
                    if (A.userName.Equals(account.userName)
                            && A.password.Equals(account.password) && account.roleId == 1)
                    {
                        check = 1;
                        List<Product> listProduct = new ProductDao().getAll();
                        List<Category> listCategory = new CategoryDao().getAll();
                        List<SubCategory> listSubCategory = new SubCategoryDao().getAll();
                        List<StatusProduct> listStatusProduct = new StatusProductDao().getAll();
                        List<StatusCategory> listStatusCategory = new StatusCategoryDao().getAll();
                        List<StatusSubCategory> listStatusSubCategory = new StatusSubCategoryDao().getAll();
                        List<Order> listOrderWatting = new OrderDao().getOrderNotSuccesYetByCustomer(account.userName, 4);

                        List<StatusAccount> listStatusAccount = new StatusAccountDao().getAll();
                        List<RoleAccount> listRoleAccount = new RoleAccountDao().getAll();
                        int numOfOrder = new OrderDao().countOrderWatting();
                        int count = new ViewDao().getView();
                        int count2 = new ProductDao().countProduct();
                        int count3 = new AccountDao().countAccount();
                        int count4 = new SubCategoryDao().countSubCategory();

                        string thu = "";
                        string data = "";
                        List<ThongkeOrder> listThongKe = new ThongKeOrderDao().getAll();
                        foreach (ThongkeOrder T in listThongKe)
                        {
                            thu += T.thu + ",";
                            data += T.numOfOrder + ",";
                        }
                        thu = thu.Remove(thu.Length - 1);

                        ViewData["thu"] = thu;
                        ViewData["data"] = data;

                        ViewData["view"] = count;
                        ViewData["numSubCategory"] = count4;
                        ViewData["numAccount"] = count3;
                        ViewData["numProduct"] = count2;
                        ViewData["numOfOrder"] = numOfOrder;
                        ViewData["listOrderWatting"] = listOrderWatting;
                        ViewData["listProduct"] = listProduct;
                        ViewData["listCategory"] = listCategory;
                        ViewData["listSubCategory"] = listSubCategory;
                        ViewData["listStatusProduct"] = listStatusProduct;
                        ViewData["listStatusCategory"] = listStatusCategory;
                        ViewData["listStatusSubCategory"] = listStatusSubCategory;
                        ViewData["listStatusAccount"] = listStatusAccount;
                        ViewData["listRoleAccount"] = listRoleAccount;
                    }
                }
                if (check == 0)
                {
                    //response.sendRedirect("client/error.jsp");
                }
            }
            else
            {
                //response.sendRedirect("login");
                Response.Redirect("~/Login/Login");
            }
            return View();
        }
    }
}