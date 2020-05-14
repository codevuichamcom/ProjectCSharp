using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers.client
{
    public class GetAllProductSallingController : Controller
    {
       
           // GET: ListAllProductSalling
            public ActionResult Index()
            {
                List<Product> listProduct = new ProductDao().getAllProductAreSaling();
                List<Category> listCategory = new CategoryDao().getAll();

                //Session["url"] =  "get-list-sale";
                TempData["listProduct"] = listProduct;
                ViewData["listCategory"] = listCategory;

                return Redirect("~/Product/listProduct");
            }
        
    }
}