using Gemma.Repository;
using Gemma.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private CheckoutRepository rep = new CheckoutRepository();

        [HttpPost]
        public ActionResult GetUncheckOrder(ConvertCartArray uncheckData)
        {
            //轉成個別LIST
            Session["unorderCart"] = rep.ConvertList(uncheckData);
            return View("CheckInfo");
        }

        // 填個人資料 (有資料才知道寄去哪)
        public ActionResult CheckInfo(string Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var data = rep.GetMemberData(Id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckInfo(CheckMemberInfoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            if (ModelState.IsValid)
            {
                rep.InfoToAspNetUser(data, User.Identity.GetUserId());
            }
            return RedirectToAction("Payment");
        }
        public ActionResult Payment() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment(CreditcardViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            if (ModelState.IsValid)
            {
                Session["CreditCard"] = JsonConvert.SerializeObject(data);
                rep.SaveOrder((List<CartViewModel>)Session["unorderCart"], User.Identity.GetUserId());
            }
            return RedirectToAction("OrderSearch", "MemberCenter");
        }

        public ActionResult Finished()
        {
            if (Session["confirm"] == null)
            {
                RedirectToAction("CartView", "Cart");
            }
            return View();
        }

        [HttpPost]
        public string CallLine(Line data)
        {
            var backData = rep.CallLinePay(data);
            return backData;
        }


        [HttpPost]
        public string FinishThenSave()
        {
            rep.FinishLinePay();
            rep.SaveOrder((List<CartViewModel>)Session["unorderCart"], User.Identity.GetUserId());
            var url = "/MemberCenter/OrderSearch/" + User.Identity.GetUserId().ToString();
            return url;
        }
    }
}