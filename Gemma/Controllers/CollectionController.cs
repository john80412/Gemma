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
                new CollectionItem { Name = "ポインテッドミラーチャンキーヒール", FileName = "1.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "ポインテッドミラーチャンキーヒール", FileName = "2.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "ポインテッドミラーチャンキーヒール", FileName = "3.jpg", Price = 16000, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥVカット2Wayフラットシューズ", FileName = "4.jpg", Price = 13000, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥVカット2Wayフラットシューズ", FileName = "5.jpg", Price = 13000, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥVカット2Wayフラットシューズ", FileName = "6.jpg", Price = 13000, Weburl = "#"},
                new CollectionItem { Name = "プラットフォームレースアップシューズ", FileName = "7.jpg", Price = 15000, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥバックジプアップブーツ", FileName = "8.jpg", Price = 21000, Weburl = "#"},
                new CollectionItem { Name = "ポインテッドストレッチブーツミラーチャンキーヒール", FileName = "9.jpg", Price = 23800, Weburl = "#"},
                new CollectionItem { Name = "フラットシューズ", FileName = "10.jpg", Price = 12800, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥバックジップアップブーツ", FileName = "11.jpg", Price = 21000, Weburl = "#"},
                new CollectionItem { Name = "フラットシューズ", FileName = "12.jpg", Price = 10000, Weburl = "#"},
                new CollectionItem { Name = "プラットフォームレースアップシュー", FileName = "13.jpg", Price = 15000, Weburl = "#"},
                new CollectionItem { Name = "スニーカー", FileName = "14.jpg", Price = 14000, Weburl = "#"},
                new CollectionItem { Name = "ポインテッドストレッチブーツミラー", FileName = "15.jpg", Price = 23800, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥラビットファースリッパ", FileName = "16.jpg", Price = 11000, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥラビットファースリッパ", FileName = "17.jpg", Price = 11000, Weburl = "#"},
                new CollectionItem { Name = "スクエアトゥラビットファースリッパ", FileName = "18.jpg", Price = 11000, Weburl = "#"},
            };

            return View(photos);
        }
    }
}