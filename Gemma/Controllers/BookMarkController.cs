using Gemma.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gemma;
using Gemma.ViewModel;
using System.Net;

namespace Gemma.Controllers
{
    public class BookMarkController : Controller
    {
        public BookMarkRespository repb = new BookMarkRespository();
        // GET: BookMark
        public ActionResult Index()
        {
            return View();
        }
        // GET: BookMark/Delete/5
        public ActionResult Delete(string? ProductName)
        {
    
            repb.DeleteBookMark(ProductName);
            return RedirectToAction("Index");
        }

        // POST: Stock/Delete/5
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repb.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}