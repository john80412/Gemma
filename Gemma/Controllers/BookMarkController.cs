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

namespace Gemma.Controllers
{
    public class BookMarkController : Controller
    {
        public ActionResult Index(bool isDeleteAll = false)
        {
            //Session["BookMark"] = new List<BookMark> { 
            //    new BookMark{ProductID = 1 ,CustomerID = "1"},
            //    new BookMark{ProductID = 2 ,CustomerID = "1" }
            //};
            if (isDeleteAll)
            {
                Session["Wish"] = null;
            }
            //List<BookMarkViewModel> bk =(List<BookMarkViewModel>) Session["Wish"]; //value 轉型成key

            return View();
        }
        public void  Addwishlist(int? ProductId)
        {
            var test = (List<BookMarkViewModel>)Session["Wish"];
            test ??= new List<BookMarkViewModel>();
            test.Add(new BookMarkViewModel { ProductId = ProductId});
            Session["Wish"]= test;
            Session["Count"]= test.Count;
        }
        public void removewishlist(int? ProductId)
        {
            var test = (List<BookMarkViewModel>)Session["Wish"];
            test ??= new List<BookMarkViewModel>();
            test.Remove((BookMarkViewModel)test.Where(x => x.ProductId == ProductId));
            Session["Wish"]= test;
            Session["Count"]= test.Count;
        }
    }
}