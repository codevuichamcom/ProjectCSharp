using Project.DAL;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class PrepareShippingController : Controller
    {
        // GET: PrepareShipping
        public ActionResult PrepareShipping()
        {
            List<Category> listCategory= TempData["listCategory"] as List<Category>;
            string note=TempData["note"].ToString();
            Shipping shipping= TempData["shipping"] as Shipping;

            ViewData["listCategory"] = listCategory;
            ViewData["note"] = note;
            ViewData["shipping"] = shipping;

            return View();
        }
        
        [HttpPost]
        public ActionResult PrepareShippingPost()
        {
            string name = Request.Form["name"];
            string mobile = Request.Form["mobile"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];


            Account account = (Account)Session["account"];
            Account accountDetail = new Account();
            if(account != null)
            {
                accountDetail = new AccountDao().getOne(account.userName);
            }
            string username = account.userName;
            Shipping shipping = new Shipping();

            shipping.name = name;
            shipping.phone = mobile;
            shipping.address=address;

            int shippingInfoId = new ShippingDao().addShippingReturnId(shipping);

            if (shippingInfoId > 0)
            {
                List<Cart> listCart = (List<Cart>)Session["listCart"];

                double totalPrice = 0;
                foreach (Cart c in listCart)
                {
                    totalPrice += c.totalPrice;
                }

                Order order = new Order();
                order.customer = username;
                order.shippingId = shippingInfoId;
                order.totalPrice = totalPrice;
                order.note = note;
                order.status=1;//đang xử lý- đang ship-thành công

                int orderId = new OrderDao().addOrderReturnId(order);
                if (orderId > 0)
                {
                    bool check = new OrderDetailDao().add(listCart, orderId);
                    if (check)
                    {
                        Session.Remove("listCart");
                        Response.Redirect("~/Thanks/Thanks");
                        string subject = "Your order is  processing.";
                        string body = "";
                        body += " <html>";
                        body += "<body>";
                        body += "<h3>Your order has been processing.</h3>";
                        body += "<table>";

                        body += "<tr>";
                        body += "<td>Full Name : </td><td>"+ shipping.name +"</td>";
                        body += "</tr>";

                        body += "<tr>";
                        body += "<td>Phone : </td><td>"+shipping.phone+"</td>";
                        body += "</tr>";

                        body += "<tr>";
                        body += "<td>address : </td><td>" + shipping.address + "</td>";
                        body += "</tr>";

                        body += "</table>";
                        body += "<h3>Thank you very much!</h3>";
                        body += "</body>";
                        body += "</html>";

                        Ultilities.SendMail.Send(accountDetail.email, subject, body);
                    }
                    else
                    {
                        //remove order (tự code)

                        int orderRemove = new OrderDao().removeOrderByShippingIdReturnId(shippingInfoId);
                        int shippingRemove = new ShippingDao().removeShippingReturnId(shippingInfoId);

                        //remove shippingInfo (tự code)
                        Response.Redirect("~/Error/error");
                    }
                }
                else
                {
                    //remove shippingInfo (tự code)
                    int shippingRemove = new ShippingDao().removeShippingReturnId(shippingInfoId);
                    Response.Redirect("~/Error/error");
                }

            }
            else
            {

                Response.Redirect("~/Error/error");
            }



            return View();
        }
    }
}