using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index() => View();
        public ActionResult Shop() => View();
    }
}