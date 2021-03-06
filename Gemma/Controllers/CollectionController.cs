﻿using Gemma.Models;
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
        public ActionResult Index() => View();

        public ActionResult CollectionPhotos()
        {
            List<CollectionItem> photos = new List<CollectionItem>
            {
                new CollectionItem { Name = "ポインテッドミラーチャンキーヒール", FileName = "1.jpg", Price = 16000, Weburl = 24},
                new CollectionItem { Name = "ポインテッドミラーチャンキーヒール", FileName = "2.jpg", Price = 16000, Weburl = 24},
                new CollectionItem { Name = "ポインテッドミラーチャンキーヒール", FileName = "3.jpg", Price = 16000, Weburl = 24},
                new CollectionItem { Name = "スクエアトゥVカット2Wayフラットシューズ", FileName = "4.jpg", Price = 13000, Weburl = 16},
                new CollectionItem { Name = "スクエアトゥVカット2Wayフラットシューズ", FileName = "5.jpg", Price = 13000, Weburl = 16},
                new CollectionItem { Name = "スクエアトゥVカット2Wayフラットシューズ", FileName = "6.jpg", Price = 13000, Weburl = 16},
                new CollectionItem { Name = "プラットフォームレースアップシューズ", FileName = "7.jpg", Price = 15000, Weburl = 19},
                new CollectionItem { Name = "スクエアトゥバックジプアップブーツ", FileName = "8.jpg", Price = 21000, Weburl = 3},
                new CollectionItem { Name = "ポインテッドストレッチブーツミラーチャンキーヒール", FileName = "9.jpg", Price = 23800, Weburl = 2},
                new CollectionItem { Name = "フラットシューズ", FileName = "10.jpg", Price = 12800, Weburl = 15},
                new CollectionItem { Name = "スクエアトゥバックジップアップブーツ", FileName = "11.jpg", Price = 21000, Weburl = 2},
                new CollectionItem { Name = "フラットシューズ", FileName = "12.jpg", Price = 10000, Weburl = 14},
                new CollectionItem { Name = "プラットフォームレースアップシュー", FileName = "13.jpg", Price = 15000, Weburl = 20},
                new CollectionItem { Name = "スニーカー", FileName = "14.jpg", Price = 14000, Weburl = 36},
                new CollectionItem { Name = "ポインテッドストレッチブーツミラー", FileName = "15.jpg", Price = 23800, Weburl = 4},
                new CollectionItem { Name = "スクエアトゥラビットファースリッパ", FileName = "16.jpg", Price = 11000, Weburl = 30},
                new CollectionItem { Name = "スクエアトゥラビットファースリッパ", FileName = "17.jpg", Price = 11000, Weburl = 30},
                new CollectionItem { Name = "スクエアトゥラビットファースリッパ", FileName = "18.jpg", Price = 11000, Weburl = 30},
            };

            return View(photos);
        }
    }
}