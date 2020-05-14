using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class MyProfileController : Controller
    {
        // GET: MyProfile
        public ActionResult MyProfile()
        {
            Account ac = (Account)Session["account"];
            Account account = new AccountDao().getOne(ac.userName);
            List<Category> listCategory = new CategoryDao().getAll();
            List<Order> listOrderWatting = new OrderDao().getOrderNotSuccesYetByCustomer(ac.userName, 4);
            List<OrderDetail> listOrderHistory = new OrderDetailDao().getAllOrderSuccess(ac.userName);

            ViewData["listOrderHistory"] = listOrderHistory;
            ViewData["listOrderWatting"] = listOrderWatting;
            ViewData["account"] = account;
            ViewData["listCategory"] = listCategory;

            if (TempData["message"] != null)
            {
                string message = TempData["message"].ToString();
                ViewData["message"] = message;
            }
            return View();
        }
    }
}