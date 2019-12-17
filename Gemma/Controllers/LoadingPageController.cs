using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class LoadingPageController : Controller
    {
        // GET: LoadingPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadingPage()
        {
            return View();
        }
    }
}