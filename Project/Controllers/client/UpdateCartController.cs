using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class UpdateCartController : Controller
    {
        // GET: UpdateCart
        [HttpPost]
        public ActionResult UpdateCart()
        {

            List<Cart> listCart = (List<Cart>)Session["listCart"];

            for (int i = 1; i <= listCart.Count; i++)
            {
                string s = "quantity" + i;
                int quantity = int.Parse(Request.Form[s]);
                listCart[i - 1].quantity = quantity;
            }
            Session["listCart"] = listCart;

            Response.Redirect("~/GetListCart/Cart");
            return View();
        }
    }
}