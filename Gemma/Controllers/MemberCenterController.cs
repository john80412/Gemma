using Gemma.Models;
using Gemma.Repository;
using Gemma.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    [Authorize]
    public class MemberCenterController : Controller
    {
        private MemberCenterRepository rep = new MemberCenterRepository();
        // GET: MemberCenterHome
        /// <summary>
        /// 只有註冊完當下可以看到，從右上角會員中心點不到該頁面。
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View(rep.GetInitialHomeView());
        }

        /// <summary>
        /// Edit ~ 会員情報
        /// 要怎麼抓到登入狀態下的ID(未綁定)
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberInfo(string Id)
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
        public ActionResult MemberInfo([Bind(Include = "Id, UserName,Password, CheckPassword, LastName, " +
            "FirstName, Mobile,Country, PostalCode, Address, DateOfBirth")]AspNetUser data)
        {
            data.SecurityStamp = new Random().Next(5).ToString();
            data.Email = data.UserName;
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            if (ModelState.IsValid)
            {
                var correct = new PasswordHasher().VerifyHashedPassword(data.PasswordHash, data.Password);

                if ((int)correct == 1)
                {
                    ViewData["error"] = "You doesn't change your password!";
                    return View(data);
                }
                data.PasswordHash = new PasswordHasher().HashPassword(data.Password);
                rep.db.Entry(data).State = EntityState.Modified;
                rep.db.SaveChanges();
            }
            return View(data);
        }


        /// <summary>
        /// 訂單查詢，要連資料庫
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderSearch()
        {
            //var order = rep.GetOrder(Id);
            //return View(order);
            return View(rep.GetSearchStock(User.Identity.Name));
        }

        [HttpPost]
        public string ResponseDetails(string orderID)
        {
            return rep.RespondOD(orderID);
        }
    }
}