using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gemma;
using Gemma.Repository;
using Gemma.ViewModel;

namespace Gemma.Controllers
{
    [Authorize(Users = "Admin@gmail.com")]
    public class ProductsController : Controller
    {
        private readonly ProductRepository rep = new ProductRepository();

        // GET: Products
        public ActionResult Index(string productName, string categoryName, int page = 1, string search = "false")
        {
            ViewBag.searchProductName = productName;
            ViewBag.searchCategoryName = categoryName;
            page = search == "true" ? 1 : page;
            return View(rep.GetSearchProduct(productName, categoryName, page));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = rep.GetProductDetail(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(rep.db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductName,UnitPrice,Discount,CategoryID,Explain")] ProductViewModel product , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                rep.CreateProduct(product,file);
                TempData["message"] = rep.IsSuccess;
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(rep.db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = rep.GetProductDetail(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(rep.db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,UnitPrice,Discount,CategoryID,Explain")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                rep.EditProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(rep.db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        //// GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = rep.GetProductDetail(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //// POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.DeleteProduct(id);
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
