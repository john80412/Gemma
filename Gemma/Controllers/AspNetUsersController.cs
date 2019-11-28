using Gemma.Repository;
using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Models
{
    public class AspNetUsersController : Controller
    {
        private MemberRepository rep = new MemberRepository();

        // GET: AspNetUsers
        public ActionResult Index(string id, int page = 1, string search = "false")
        {
            ViewBag.searchMemberId = id;
            page = search == "true" ? 1 : page;
            return View(rep.GetSearchMember(id, page));
        }

        // GET: AspNetUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = rep.GetMemberDetail(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: AspNetUsers/Create
        //public ActionResult Create()
        //{
        //    ViewBag.Id = new SelectList(rep.db.AspNetUsers, "Id", "Id");
        //    ViewBag.UserName = new SelectList(rep.db.AspNetUsers, "UserName", "UserName");
        //    ViewBag.Email = new SelectList(rep.db.AspNetUsers, "Email", "Email");
        //    ViewBag.PhoneNumber = new SelectList(rep.db.AspNetUsers, "PhoneNumber", "PhoneNumber");
        //    return View();
        //}

        // POST: AspNetUsers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,UserName,Email,PhoneNumber")] MemberViewModel member)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        rep.CreatMember(member);
        //        TempData["message"] = rep.IsSuccess;
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.Id = new SelectList(rep.db.AspNetUsers, "Id", "Id");
        //    ViewBag.UserName = new SelectList(rep.db.AspNetUsers, "UserName", "UserName", member.UserName);
        //    ViewBag.Email = new SelectList(rep.db.AspNetUsers, "Email", "Email", member.Email);
        //    ViewBag.PhoneNumber = new SelectList(rep.db.AspNetUsers, "PhoneNumber", "PhoneNumber", member.PhoneNumber);

        //    return View(member);
        //}

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var member = rep.GetMemberDetail(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserName = new SelectList(rep.db.AspNetUsers, "UserName", "UserName", member.UserName);
            ViewBag.Email = new SelectList(rep.db.AspNetUsers, "Email", "Email", member.Email);
            ViewBag.PhoneNumber = new SelectList(rep.db.AspNetUsers, "PhoneNumber", "PhoneNumber", member.PhoneNumber);

            return View(member);
        }

        // POST: AspNetUsers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,PhoneNumber")]  MemberViewModel member)
        {
            if (ModelState.IsValid)
            {
                rep.EditMember(member);
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(rep.db.AspNetUsers, "UserName", "UserName", member.UserName);
            ViewBag.Email = new SelectList(rep.db.AspNetUsers, "Email", "Email", member.Email);
            ViewBag.PhoneNumber = new SelectList(rep.db.AspNetUsers, "PhoneNumber", "PhoneNumber", member.PhoneNumber);

            return View(member);
        }

        // GET: AspNetUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var member = rep.GetMemberDetail(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rep.DeleteMember(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rep.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
