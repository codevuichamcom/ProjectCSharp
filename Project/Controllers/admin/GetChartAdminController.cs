using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.admin
{
    public class GetChartAdminController : Controller
    {
        // GET: GetChartAdmin
        public ActionResult GetChartAdmin()
        {
            List<Product> listProduct = new ProductDao().getAll();
            List<Category> listCategory = new CategoryDao().getAll();
            List<SubCategory> listSubCategory = new SubCategoryDao().getAll();
            List<StatusProduct> listStatusProduct = new StatusProductDao().getAll();
            List<StatusCategory> listStatusCategory = new StatusCategoryDao().getAll();
            List<StatusSubCategory> listStatusSubCategory = new StatusSubCategoryDao().getAll();
            //                        List<Order> listOrderWatting = new OrderDao().getOrderNotSuccesYetByCustomer(account.getUserName(), 4);
            int numOfOrder = new OrderDao().countOrderWatting();
            int count = new ViewDao().getView();
            int count2 = new ProductDao().countProduct();
            int count3 = new AccountDao().countAccount();
            int count4 = new SubCategoryDao().countSubCategory();
            string label = "";
            string soluong = "";
            List<int> soluongProduct = new ProductDao().countProductGroupByCategoryId();
            foreach (Category C in listCategory)
            {
                label += "" + C.category + ",";
            }
            label.Remove(label.Length - 1);
            label.Substring(0, label.Length - 1);
            foreach (int integer in soluongProduct)
            {
                soluong += (double)Math.Round((((double)integer / count2) * 100) * 100) / 100 + ",";
            }
            soluong.Substring(0, soluong.Length - 1);
            List<double> listRevenue = new List<double>();

            double a = new OrderDao().calRevenueInMonth(4);
            listRevenue.Add(a);

            string revenue = "";
            foreach (Double double1 in listRevenue)
            {
                revenue += (double)Math.Round(double1 * 100) / 100 + ",";
            }
            revenue.Substring(0, revenue.Length - 1);


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
            ViewData["label"] = label;
            ViewData["soluong"] = soluong;
            ViewData["revenue"] = revenue;

            ViewData["view"] = count;
            ViewData["numSubCategory"] = count4;
            ViewData["numAccount"] = count3;
            ViewData["numProduct"] = count2;

            ViewData["numOfOrder"] = numOfOrder;
            ViewData["listProduct"] = listProduct;
            ViewData["listCategory"] = listCategory;
            ViewData["listSubCategory"] = listSubCategory;
            ViewData["listSubCategory"] = listSubCategory;
            ViewData["listStatusCategory"] = listStatusCategory;
            ViewData["listStatusSubCategory"] = listStatusSubCategory;

            return View();
        }
    }
}