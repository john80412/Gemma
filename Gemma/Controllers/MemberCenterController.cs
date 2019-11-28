using Gemma.Models;
using Gemma.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
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
        public ActionResult MemberInformation(string? id)
        {
            //  1. 後端先寫好保存帳密的資料，會員中心讀取直接回寫到資料庫，可以自己寫或借session
            //  2. 頭頂加[Authorize]
            if (id == null)
            {
                return RedirectToAction("Index", "XXXcontroller"); //要併成到登入頁面
            }
            var data = rep.GetMemberData(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemberInformation([Bind(Include = "Id, Email, Password, CheckPassword, LastName, " +
            "FirstName, Mobile,Country, PostalCode, Address, DateOfBirth")]AspNetUser data)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult OrderSearch(string? id)
        {
            var order = rep.GetOrder(id);
            return View(order);
        }
    }
}