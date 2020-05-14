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
    public class ProductController : Controller
    {
        // GET: GetListProduct
        public ActionResult listProduct()
        {
            const int PAGESIZE = 20;
            ProductDao productDao = new ProductDao();
            int pageindex = NumberHelper.getInt(Request.QueryString["page"]);
            int pageCount = productDao.countPage();
            pageCount = (pageCount % PAGESIZE == 0) ? pageCount / PAGESIZE : pageCount / PAGESIZE + 1;
            List<int> listCount = new List<int>();
            for (int i = 1; i <= pageCount; i++)
            {
                listCount.Add(i);
            }
            if (pageindex == -1)
            {
                pageindex = 1;
            }
            List<Product> listProduct = new List<Product>();
            if (TempData["listProduct"] != null)
            {
                listProduct = TempData["listProduct"] as List<Product>;
            }
            else
            {
                listProduct = productDao.getAllPaging(pageindex, PAGESIZE);
            }
            List<Category> listCategory = new CategoryDao().getAll();
            ViewData["page"] = pageindex;
            ViewData["listCount"] = listCount;
            ViewData["listProduct"] = listProduct;
            ViewData["listCategory"] = listCategory;
            Session["url"] = "https://localhost:44394/Product/listProduct";
            return View();
        }
    }
}