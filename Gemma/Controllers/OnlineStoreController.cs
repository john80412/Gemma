using Gemma.Models;
using Gemma.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using System.IO;

namespace Gemma.Controllers
{
    public class OnlineStoreController : Controller
    {
        public GemmaDBContext db = new GemmaDBContext();
        // GET: OnlineStore
        //public ActionResult Index()
        //{
        //    return View();
        //}

        /////呼叫PictureCatch()方法
        //public ActionResult OnlineStore()
        //{
        //    return View(PictureCatch());
        //}

        /////呼叫OnlineStore_Category_pumps()方法
        //public ActionResult OnlineStore_Category_PUMPS()
        //{
        //    return View(Category_pumps());
        //}

        //public ActionResult OnlineStore_Category_FLATSHOES()
        //{
        //    return View(Category_FLATSHOES());
        //}

        //public ActionResult OnlineStore_Category_MANNISH()
        //{
        //    return View(Category_MANNISH());
        //}

        //public ActionResult OnlineStore_Category_SNEAKER()
        //{
        //    return View(Category_SNEAKER());
        //}

        //public ActionResult OnlineStore_Category_SANDAL()
        //{
        //    return View(Category_SANDAL());
        //}

        //public ActionResult OnlineStore_Category_BOOTS()
        //{
        //    return View(Category_BOOTS());
        //}



        public ActionResult FindBrand(string category)
        {

            List<OnlineStore> result = null;
            if (string.IsNullOrEmpty(category) || category.Trim().ToUpper() == "All")
            {
                //List<OnlineStore> result = null;
                //var listStock = db.Stocks.ToList();
                result = (from s in db.Stocks.Include(s => s.Product.Category)
                          where s.Product.Category.CategoryID == s.Product.CategoryID
                          select new OnlineStore
                          {
                              Id = s.ProductID,
                              Category = s.Product.Category.CategoryName,
                              Picture = s.ImageName,
                              Heart = "/Heart_Mark.png",
                              Next = "next.png",
                              Prev = "prev.png",
                              Brand = "GEMMA LINN",
                              ProductName = "ベロアバレエシューズ",
                              Price = s.Product.UnitPrice,
                              Tax = " + TAX"
                          }
                                ).Distinct().ToList();
            }
            else
            {
                //List<OnlineStore> result = null;

                result = (from s in db.Stocks.Include(s => s.Product.Category)
                                where s.Product.Category.CategoryName == category
                                select new OnlineStore
                                {
                                    Id = s.ProductID,
                                    Category = s.Product.Category.CategoryName,
                                    Picture = s.ImageName,
                                    Heart = "/Heart_Mark.png",
                                    Next = "next.png",
                                    Prev = "prev.png",
                                    Brand = "GEMMA LINN",
                                    ProductName = "ベロアバレエシューズ",
                                    Price = s.Product.UnitPrice,
                                    Tax = " + TAX"
                                }
                                ).Distinct().ToList();

            }


            //if (result.Count == 0)
            //{
            //    return View(result);
            //}
            //else
            //{
            //    ViewBag.Header = result[0].Brand;
            //}

            return View(result);
        }




        //public List<OnlineStore> PictureCatch()
        //{
        //    #region 暫時收
        //    //List<OnlineStore> pictures = new List<OnlineStore>
        //    //{
        //    //    new OnlineStore{Id = 1,Picture="/SNEAKER/Python pattern slip-ons/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///SNEAKER/Python pattern slip-ons/index1.jpg
        //    //    new OnlineStore{Id = 2,Picture="/FLATSHOES/Square toe V-cut 2 way flat shoes/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///FLATSHOES/Square toe V-cut 2 way flat shoes/index1.jpg
        //    //    new OnlineStore{Id = 3,Picture="/BOOTS/Chunky heel ankle boots/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///BOOTS/Chunky heel ankle boots/index1.jpg

        //    //    new OnlineStore{Id = 4,Picture="/BOOTS/Studded short boots/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///BOOTS/Studded short boots/index1.jpg
        //    //    new OnlineStore{Id = 5,Picture="/BOOTS/Side cut ankle boots/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///BOOTS/Side cut ankle boots/index1.jpg
        //    //    new OnlineStore{Id = 6,Picture="/BOOTS/Suede stretch boots/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///BOOTS/Suede stretch boots/index1.jpg

        //    //    new OnlineStore{Id = 7,Picture="/BOOTS/Python pattern stretch boots/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///BOOTS/Python pattern stretch boots/index1.jpg
        //    //    new OnlineStore{Id = 8,Picture="/BOOTS/Square toe short boots/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///BOOTS/Square toe short boots/index1.jpg
        //    //    new OnlineStore{Id = 9,Picture="index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    //從缺??

        //    //    new OnlineStore{Id = 10,Picture="/PUMPS/Ankle strap pointed double line pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///PUMPS/Ankle strap pointed double line pumps/index1.jpg
        //    //    new OnlineStore{Id = 11,Picture="/PUMPS/45mm chunky heel V cut pointed pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///PUMPS/45mm chunky heel V cut pointed pumps/index1.jpg
        //    //    new OnlineStore{Id = 12,Picture="/PUMPS/Pointed enamel loafers pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///PUMPS/Pointed enamel loafers pumps/index1.jpg

        //    //    new OnlineStore{Id = 13,Picture="index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    //從缺??
        //    //    new OnlineStore{Id = 14,Picture="/PUMPS/45mm pointed pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///PUMPS/45mm pointed pumps/index1.jpg
        //    //    new OnlineStore{Id = 15,Picture="/PUMPS/65mm pointed pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///PUMPS/65mm pointed pumps/index1.jpg

        //    //    new OnlineStore{Id = 16,Picture="/PUMPS/Pointed shoe tea pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///PUMPS/Pointed shoe tea pumps/index1.jpg
        //    //    new OnlineStore{Id = 17,Picture="/FLATSHOES/Suede ribbon pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    ///FLATSHOES/Suede ribbon pumps/index1.jpg
        //    //    new OnlineStore{Id = 18,Picture="index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="Daniella Tam"},
        //    //    //從缺??

        //    //    new OnlineStore{Id = 19,Picture="/FLATSHOES/Pointed ballet shoes/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///FLATSHOES/Pointed ballet shoes/index1.jpg
        //    //    new OnlineStore{Id = 20,Picture="/FLATSHOES/Poodle separate flat pumps/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///FLATSHOES/Poodle separate flat pumps/index1.jpg
        //    //    new OnlineStore{Id = 21,Picture="/FLATSHOES/Square ballet shoes studs heel/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///FLATSHOES/Square ballet shoes studs heel/index1.jpg

        //    //    new OnlineStore{Id = 22,Picture="/FLATSHOES/Star motif opera shoes/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///FLATSHOES/Star motif opera shoes/index1.jpg
        //    //    new OnlineStore{Id = 23,Picture="/MANNISH/2WAY bit loafer/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///MANNISH/2WAY bit loafer/index1.jpg
        //    //    new OnlineStore{Id = 24,Picture="/MANNISH/2WAY suede loafers/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    ///MANNISH/2WAY suede loafers/index1.jpg

        //    //    new OnlineStore{Id = 25,Picture="/MANNISH/Bit heel loafers/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /MANNISH/Bit heel loafers/index1.jpg
        //    //    new OnlineStore{Id = 26,Picture="/MANNISH/Lace-up shoes/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /MANNISH/Lace-up shoes/index1.jpg
        //    //    new OnlineStore{Id = 27,Picture="/MANNISH/Medallion platform lace-up shoes/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /MANNISH/Medallion platform lace-up shoes/index1.jpg

        //    //    new OnlineStore{Id = 28,Picture="/MANNISH/Round toe platform loafers/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /MANNISH/Round toe platform loafers/index1.jpg
        //    //    new OnlineStore{Id = 29,Picture="/SANDAL/2way ribbon mules/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /SANDAL/2way ribbon mules/index1.jpg
        //    //    new OnlineStore{Id = 30,Picture="/SANDAL/Pointed Rabbit Farm Mule/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /SANDAL/Pointed Rabbit Farm Mule/index1.jpg

        //    //    new OnlineStore{Id = 31,Picture="/SANDAL/Square Tour Rabbit Fur Slipper Mule/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /SANDAL/Square Tour Rabbit Fur Slipper Mule/index1.jpg
        //    //    new OnlineStore{Id = 32,Picture="/SNEAKER/Eco Fur & Pony Slip-ons/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /SNEAKER/Eco Fur & Pony Slip-ons/index1.jpg
        //    //    new OnlineStore{Id = 33,Picture="/SNEAKER/Knit high-top sneakers/index1.jpg",Heart="/Heart_Mark.png",Next="next.png",Prev="prev.png",Brand="GEMMA LINN"},
        //    //    // /SNEAKER/Knit high-top sneakers/index1.jpg

        //    //};
        //    #endregion

        //    List<OnlineStore> result = new List<OnlineStore>();

        //    //var listStock = db.Stocks.ToList();
        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == s.Product.CategoryID)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };


        //    //foreach (var item in listStock)
        //    //{
        //    //    var storeItem = new OnlineStore()
        //    //    {
        //    //        Id = item.ProductID,
        //    //        Picture = item.ImageName,           
        //    //        Heart = "/Heart_Mark.png",
        //    //        Next = "next.png",
        //    //        Prev = "prev.png",
        //    //        Brand = "GEMMA LINN"
        //    //    };

        //    //    result.Add(storeItem);

        //    //}

        //    return listStock.Distinct().ToList();
        //}

        //public List<OnlineStore> Category_pumps()
        //{
        //    List<OnlineStore> result = new List<OnlineStore>();

        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == 1)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };
        //    return listStock.Distinct().ToList();
        //}

        //public List<OnlineStore> Category_FLATSHOES()
        //{
        //    List<OnlineStore> result = new List<OnlineStore>();

        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == 2)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };
        //    return listStock.Distinct().ToList();
        //}

        //public List<OnlineStore> Category_MANNISH()
        //{
        //    List<OnlineStore> result = new List<OnlineStore>();

        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == 3)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };
        //    return listStock.Distinct().ToList();
        //}

        //public List<OnlineStore> Category_SNEAKER()
        //{
        //    List<OnlineStore> result = new List<OnlineStore>();

        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == 4)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };
        //    return listStock.Distinct().ToList();
        //}

        //public List<OnlineStore> Category_SANDAL()
        //{
        //    List<OnlineStore> result = new List<OnlineStore>();

        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == 5)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };
        //    return listStock.Distinct().ToList();
        //}

        //public List<OnlineStore> Category_BOOTS()
        //{
        //    List<OnlineStore> result = new List<OnlineStore>();

        //    var listStock = from s in db.Stocks.Include(s => s.Product.Category)
        //                    where (s.Product.Category.CategoryID == 6)
        //                    select new OnlineStore
        //                    {
        //                        Id = s.ProductID,
        //                        Category = s.Product.Category.CategoryName,
        //                        Picture = s.ImageName,
        //                        Heart = "/Heart_Mark.png",
        //                        Next = "next.png",
        //                        Prev = "prev.png",
        //                        Brand = "GEMMA LINN",
        //                        ProductName = "ベロアバレエシューズ",
        //                        Price = s.Product.UnitPrice,
        //                        Tax = " + TAX"
        //                    };
        //    return listStock.Distinct().ToList();
        //}
    }
}