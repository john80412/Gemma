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
        SingleProductRepository productRepository = new SingleProductRepository();

        // GET: Details
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FindProductById(int? productId)
        {
            SingleProductDetailViewModel product = productRepository.GetSingleDetails(productId);

            if (productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

      

    }
}