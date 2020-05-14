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
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult FilterByCategory()
        {
            SubCategoryDao subCategoryDao = new SubCategoryDao();

            int pageindex = NumberHelper.getInt(Request.QueryString["page"]);
            List<int> listCount = new List<int>();
            int pageCount;
            if (pageindex == -1)
            {
                pageindex = 1;
            }
            int id = NumberHelper.getInt(Request.QueryString["id"]);
            int cid = NumberHelper.getInt(Request.QueryString["cid"]);
            if (id == -1 && cid == -1)
            {
                Response.Redirect("Error");
            }
            else
            {
                List<Product> listProduct;
                List<Category> listCategory;
                if (cid == -1)
                {
                    if (id == 0)
                    {
                        listProduct = new ProductDao().getAllPaging(pageindex, 20);
                        pageCount = new ProductDao().countPage();


                    }
                    else
                    {
                        listProduct = new ProductDao().getAllByCategoryIdPaging(id, pageindex, 20);
                        pageCount = new ProductDao().countPageByCategory(id);
                    }
                }
                else
                {
                    if (cid == 0)
                    {
                        listProduct = new ProductDao().getAllPaging(pageindex, 20);
                        pageCount = new ProductDao().countPage();
                    }
                    else
                    {
                        listProduct = new ProductDao().getAllBySubCategoryIdPaging(cid, pageindex, 20);
                        pageCount = new ProductDao().countPageBySubCategory(id);
                    }
                }
                pageCount = (pageCount % 20 == 0) ? pageCount / 20 : pageCount / 20 + 1;
                for (int i = 1; i <= pageCount; i++)
                {
                    listCount.Add(i);
                }
                listCategory = new CategoryDao().getAll();

                ViewData["id"] = id;
                ViewData["cid"] = id;
                ViewData["page"] = pageindex;
                ViewData["listCount"] = listCount;
                ViewData["listProduct"] = listProduct;
                ViewData["listCategory"] = listCategory;

            }
            return View();
        }
    }
}