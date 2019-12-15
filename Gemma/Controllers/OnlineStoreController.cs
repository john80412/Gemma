using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Gemma.ViewModel;
using Gemma.Repository;

namespace Gemma.Controllers
{
    public class OnlineStoreController : Controller
    {
        private OnlineStoreRepository repo = new OnlineStoreRepository();
        // GET: OnlineStore
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OnlineStorePage(string CategoryName, string ColorName, string OrderBy)
        {
            if (OrderBy == "LowToHigh")
            {
                Session["PriceOrderBy"] = OrderBy;
                List<OnlineStoreProductVM> ProductsVMOrderBy = (List<OnlineStoreProductVM>)Session["ProductModel"];
                ProductsVMOrderBy = ProductsVMOrderBy.OrderBy(x => x.UnitPrice).ToList();
                return View(ProductsVMOrderBy);
                //return Content("由小到大");
            }
            else if (OrderBy == "HighToLow")
            {
                Session["PriceOrderBy"] = OrderBy;
                List<OnlineStoreProductVM> ProductsVMOrderBy = (List<OnlineStoreProductVM>)Session["ProductModel"];
                ProductsVMOrderBy = ProductsVMOrderBy.OrderByDescending(x => x.UnitPrice).ToList();
                return View(ProductsVMOrderBy);
                //return Content("由大到小");
            }
            else
            {
                Session["PriceOrderBy"] = "None";
            }


            // 建立 Session 保存 CategoryName 和 ColorName
            if (Session["CategoryName"] == null && Session["ColorName"] == null)
            {
                Session["CategoryName"] = "ALL";
                Session["ColorName"] = "ALL";
                CategoryName = (string)Session["CategoryName"];
                ColorName = (string)Session["ColorName"];
            }
            else if (ColorName == "ALL")
            {
                Session["CategoryName"] = CategoryName;
                Session["ColorName"] = "ALL";
            }
            else if (CategoryName == "ALL")
            {
                Session["CategoryName"] = "ALL";
                Session["ColorName"] = ColorName;
            }
            else
            {
                Session["CategoryName"] = CategoryName;
                Session["ColorName"] = ColorName;
            }


            List<OnlineStoreProductVM> ProductsVM;

            if (CategoryName == "ALL" && ColorName == "ALL")
            {
                ProductsVM = repo.GetProductsAll();
            }
            else if (ColorName == "ALL")
            {
                ProductsVM = repo.GetProductsWhenCategoryChoose(CategoryName);
            }
            else if (CategoryName == "ALL")
            {
                ProductsVM = repo.GetProductsWhenColorChoose(ColorName);
            }
            else
            {
                ProductsVM = repo.GetProductsWhenCategoryAndColorChoose(CategoryName, ColorName);
            }



            if (Session["ProductModel"] == null)
            {
                Session["ProductModel"] = ProductsVM;
            }
            else
            {
                Session["ProductModel"] = ProductsVM;
            }


            return View(ProductsVM);

        }







        public ActionResult OnlineStore()
        {
            //public List<Stock> GetShoesPicture()
            //{
            //    var Shoes = new List<Stock>();
            //    var ShoesItem = db.Stocks.ToList();
            //    foreach (var item in ShoesItem)
            //    {
            //        Shoes.Add(new Stock()
            //        {
            //            Id = item.ProductID,
            //            Picture = item.ImageName,
            //            Color = new string[] { }
            //        });
            //    }
            //    return Shoes;
            //}

            return View();
        }
    }
}