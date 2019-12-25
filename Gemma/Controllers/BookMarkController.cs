using Gemma.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gemma;
using Gemma.ViewModel;
using System.Net;
using System.Windows.Documents;
using System.Data.Entity;

namespace Gemma.Controllers
{
    public class BookMarkController : Controller
    {
        private GemmaDBContext db = new GemmaDBContext();
        public ActionResult Index(bool isDeleteAll = false)
        {
            if (isDeleteAll)
            {
                Session["Wish"] = null;
                Session["Count"] = 0;
            }
            var test = (List<BookMarkViewModel>)Session["Wish"];
            test ??= new List<BookMarkViewModel>();
            foreach (var item in test)
            {
                var x = db.Products.Include(x => x.Category).Where(x => x.ProductID == item.ProductId).ToList()[0]; /*tolist中第一個，ID是唯一*/
                (item.ProductName, item.UnitPrice, item.CategoryName) = (x.ProductName, x.UnitPrice, x.Category.CategoryName);
            }
            Session["Wish"] = test; /*更新session值*/
            return View();
        }
        public int Addwishlist(int? ProductId )
        {
            var test = (List<BookMarkViewModel>)Session["Wish"];
            test ??= new List<BookMarkViewModel>();
            test.Add(new BookMarkViewModel { ProductId = ProductId });
            Session["Wish"] = test;
            Session["Count"] = test.Count;
            return test.Count;
        }
        public int Removewishlist(int? ProductId)
        {
            var test = (List<BookMarkViewModel>)Session["Wish"];
            test ??= new List<BookMarkViewModel>();
            test.Remove(test.Where(x => x.ProductId == ProductId).ToList()[0]);
            Session["Wish"] = test;
            Session["Count"] = test.Count;
            return test.Count;
        }
        
    }
}