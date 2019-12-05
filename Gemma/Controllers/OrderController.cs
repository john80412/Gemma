using Gemma.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository rep = new OrderRepository();
        // GET: Order
        public ActionResult Index(string customerName, string productNames, int page = 1, string search = "false")
        {
            ViewBag.searchCustomerName = customerName;
            ViewBag.searchProductNames = productNames;
            page = search == "true" ? 1 : page;
            return View(rep.GetSearchStock(customerName, productNames,page));
        }
        //public ActionResult Details(int? orderID)
        //{
        //    if (orderID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var stock = rep.GetOrderDetail(productID, colorID, sizeID);
        //    if (stock == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(stock);
        //}
    }
}