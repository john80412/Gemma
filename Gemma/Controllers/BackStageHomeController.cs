using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    [Authorize(Users = "Admin@gmail.com")]
    public class BackStageHomeController : Controller
    {
        // GET: BackStageHome
        public ActionResult Index() => View();
    }
}