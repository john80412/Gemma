using Gemma.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class OnlineStoreController : Controller
    {
        public GemmaDBContext db = new GemmaDBContext();
        // GET: OnlineStore
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnlineStore()
        {
            public List<Stock> GetShoesPicture()
            {
                var Shoes = new List<Stock>();
                var ShoesItem = db.Stocks.ToList();
                foreach (var item in ShoesItem)
                {
                    Shoes.Add(new Stock()
                    {
                        Id = item.ProductID,
                        Picture = item.ImageName,
                        Color = new string[] { }
                    });
                }
                return Shoes;
            }

            return View();
        }
    }
}