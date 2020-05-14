using Project.Models;
using Project.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class DeleteCartController : Controller
    {
        // GET: DeleteCart
        public ActionResult Index()
        {

            int flag = NumberHelper.getInt(Request.QueryString["flag"]);
            if (flag == -1)
            {
                Response.Redirect("~/Error/error");
            }
            else
            {

                if (flag == 0)
                {
                    Session.Remove("listCart");
                }
                else
                {
                    //remove one
                    int id = NumberHelper.getInt(Request.QueryString["id"]);
                    if (id == -1)
                    {
                        Response.Redirect("~/Error/error");
                    }
                    else
                    {
                        List<Cart> listCart = (List<Cart>)Session["listCart"];
                        for (int i=0;i<listCart.Count;i++)
                        {
                            if (id == listCart[i].productId)
                            {
                                listCart.RemoveAt(i);
                            }
                        }
                        Session["listCart"] = listCart;
                    }

                }
                Response.Redirect("~/GetListCart/Cart");

            }

            return View();
        }
    }
}