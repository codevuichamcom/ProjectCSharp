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
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult detail()
        {
            int id = NumberHelper.getInt(Request.QueryString["id"]);
            if (id == -1)
            {
                Response.Redirect("Error");
            }
            else
            {
                Product product = new ProductDao().getOne(id);
                List<Image> listImage = new ImageDao().getAllImageByProductId(id);

                Image image = new Image();
                image.productId = product.id;
                image.imageName = product.image;
                image.status = 1;   
                listImage.Insert(0, image);


                List<Category> listCategory = new CategoryDao().getAll();
                ViewData["product"] = product;
                ViewData["listImage"] = listImage;
                ViewData["listCategory"] = listCategory;
                Session["url"] = "https://localhost:44394/ProductDetail/detail?id="+id;
                return View();
            }
            
            return View();
        }
    }
}