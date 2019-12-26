using Gemma.Models;
using Gemma.Repository;
using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace Gemma.Controllers
{
    public class DetailsController : Controller
    {
        private readonly SingleProductRepository productRepository = new SingleProductRepository();

        // GET: Details
        public ActionResult Index() => View();

        public ActionResult FindProductById(int? productId)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SingleProductDetailViewModel product = productRepository.GetSingleDetails(productId);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

      

    }
}