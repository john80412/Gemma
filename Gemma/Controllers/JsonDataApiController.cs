using Gemma.Models;
using Gemma.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class JsonDataApiController : Controller
    {
        SingleProductRepository productRepository = new SingleProductRepository();

        // GET: JsonDataApi
        public ActionResult Index() => View();

        public JsonResult FindSizeCount(int? productId, int? colorId)
        {
            List<ProductSizeDetails> pSizeDetails = productRepository.GetProductSizes(productId, colorId);

            //if (productId == null || colorId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //if (pSizeDetails == null)
            //{
            //    return HttpNotFound();
            //}

            return Json(JsonConvert.SerializeObject(pSizeDetails), JsonRequestBehavior.AllowGet);

        }
    }
}