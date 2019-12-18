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
        SingleProductRepository productRepository = new SingleProductRepository();
        public ActionResult Index(bool isDeleteAll = false)
        {
            if (isDeleteAll)
            {
                Session["BookMark"] = null;
            }
            List<BookMark> bk =(List<BookMark>) Session["BookMark"]; //value 轉型成key

            return View(bk);
        }
    }
}