using Gemma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CollectionPhotos()
        {
            List<CollectionItem> photos = new List<CollectionItem>
            {
                new CollectionItem { Name = "test", FileName = "1.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "2.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "3.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "4.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "5.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "6.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "7.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "8.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "9.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "10.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "11.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "12.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "13.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "14.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "15.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "16.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "17.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "test", FileName = "18.jpg", Price = 16000, Weburl = "#"},
            };

            return View(photos);
        }
    }
}