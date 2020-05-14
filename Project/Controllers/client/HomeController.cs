using Project.DAL;
using Project.Models;
using Project.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ProductDao productDao = new ProductDao();

            List<Product> listTemp = productDao.getAll();
            List<Product> listProduct = new List<Product>();
            ShuffleList.Shuffle(listTemp);
            for (int i = 0; i < 12; i++)
            {
                listProduct.Add(listTemp[i]);
            }

            listTemp = productDao.getAllByCategoryId(2);
            List<Product> listMeasurement = new List<Product>();
            ShuffleList.Shuffle(listTemp);
            for (int i = 0; i < 12; i++)
            {
                listMeasurement.Add(listTemp[i]);
            }

            listTemp = productDao.getAllByCategoryId(5);
            List<Product> listHomeAndGarden = new List<Product>();
            ShuffleList.Shuffle(listTemp);
            for (int i = 0; i < 12; i++)
            {
                listHomeAndGarden.Add(listTemp[i]);
            }

            listTemp = productDao.getAllByCategoryId(1);
            List<Product> listTool = new List<Product>();
            ShuffleList.Shuffle(listTemp);
            for (int i = 0; i < 12; i++)
            {
                listTool.Add(listTemp[i]);
            }

            List<Product> newArrival = productDao.sortByDateDesc();


            List<Category> listCategory = new CategoryDao().getAll();

            ViewData["listProduct"] = listProduct;
            ViewData["listMeasurement"] = listMeasurement;
            ViewData["listHomeAndGarden"] = listHomeAndGarden;
            ViewData["listTool"] = listTool;
            ViewData["newArrival"] = newArrival;
            ViewData["listCategory"] = listCategory;
            Session["url"] = "https://localhost:44394/Home/Index";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}