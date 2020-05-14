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
    public class AddToCartController : Controller
    {
        // GET: AddToCart
        public ActionResult Index()
        {
            Account account = (Account)Session["account"];
            if (account == null)
            {
                Response.Redirect("https://localhost:44394/Login/Login");
            }
            else
            {


                int productId = NumberHelper.getInt(Request.QueryString["id"]);
                Product product = new ProductDao().getOne(productId);

                Cart cart = new Cart();
                cart.productId = product.id;
                cart.productName = product.name;
                cart.productImg = product.image;
                cart.productPrice = product.price;
                cart.productQuantity = product.quantity;
                cart.quantity = 1;
                cart.totalPrice = product.price;

                List<Cart> listCart = (List<Cart>)Session["listCart"];
                if (listCart == null)
                {
                    listCart = new List<Cart>();
                    listCart.Add(cart);
                }
                else
                {
                    bool isCheck = true;
                    foreach (Cart c in listCart)
                    {
                        if (c.productId == productId)
                        {
                            c.quantity = c.quantity + 1;
                            isCheck = false;
                        }
                    }
                    if (isCheck)
                    {
                        listCart.Add(cart);
                    }
                }
                Session["listCart"] = listCart;

                string url = Session["url"].ToString();
                Response.Redirect(url);
            }
            return View();
        }
    }
}