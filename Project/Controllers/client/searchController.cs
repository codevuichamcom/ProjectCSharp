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
    public class searchController : Controller
    {
        // GET: search
        public ActionResult search()
        {
            String text = Request.QueryString["inputSearch"];
            int pageindex = NumberHelper.getInt(Request.QueryString["page"]);
            int pageCount = new ProductDao().countProductWhenSearch(text);
            pageCount = (pageCount % 20 == 0) ? pageCount / 20 : pageCount / 20 + 1;
            List<int> listCount = new List<int>();
            for (int i = 1; i <= pageCount; i++)
            {
                listCount.Add(i);
            }
            if (pageindex == -1)
            {
                pageindex = 1;
            }

            List<Product> listProduct = new ProductDao().search(text, pageindex, 20);
            List<Category> listCategory = new CategoryDao().getAll();

            ViewData["page"]= pageindex;
            ViewData["inputSearch"] = text;
            ViewData["listCount"] = listCount;
            ViewData["listProduct"] = listProduct;
            ViewData["listCategory"] = listCategory;
            Session["url"] = "~/search/search?inputSearch=" + text;
            return View();
        }
    }
}