using Gemma.Models;
using Gemma.Repository;
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
        /// <summary>
        /// For Home
        /// </summary>
        List<MemberCenter> HomeItem = new List<MemberCenter>
        {
            new MemberCenter{Item = "会員情報の編集", ItemDesciption = "Eメール、パスワード、配送・注文者情報やその他の会員情報の変更", NextUrl = "/MemberCenter/MemberInformation"},
            new MemberCenter{Item = "注文", ItemDesciption = "注文検索", NextUrl = "/MemberCenter/OrderSearch"},
            new MemberCenter{Item = "BOOKMARK", ItemDesciption = "BOOKMARK一覧へ", NextUrl = "#"},
        };
        // GET: MemberCenterHome
        /// <summary>
        /// 只有註冊完當下可以看到，從右上角會員中心點不到該頁面。
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View(HomeItem);
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
        public ActionResult MemberInfo([Bind(Include = "Id, Email, Password, LastName, " +
            "FirstName, Mobile,Country, PostalCode, Address, DateOfBirth")]AspNetUser data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            if (ModelState.IsValid)
            {
                data.Password = new PasswordHasher().HashPassword(data.Password);
                rep.db.Entry(data).State = EntityState.Modified;
                rep.db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(data);
        }


        /// <summary>
        /// 訂單查詢，要連資料庫
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderSearch(string Id)
        {
            var order = rep.GetOrder(Id);
            return View(order);
        }
    }
}