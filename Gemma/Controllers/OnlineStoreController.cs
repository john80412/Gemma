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
using Gemma.Repository;

namespace Gemma.Controllers
{
    public class OnlineStoreController : Controller
    {
        private OnlineStoreRepository repo = new OnlineStoreRepository();
        public ActionResult FindBrand(string CategoryName, string ColorName, string OrderBy)
        {
            if (CategoryName == null && ColorName == null && OrderBy == null)
            {
                List<OnlineStoreProductVM> result = null;
                //List<OnlineStore> result = null;
                //var listStock = db.Stocks.ToList();
                result = (from s in repo.db.Stocks.Include(s => s.Product.Category).Include(s => s.Product)
                          select new OnlineStoreProductVM
                          {
                              ProductId = s.ProductID,
                              CategoryName = s.Product.Category.CategoryName,
                              ProductName = s.Product.ProductName,
                              UnitPrice = s.Product.UnitPrice
                          }
                                ).Distinct().ToList();
                foreach (var item in result)
                {
                    item.ColorName = new List<string>();
                    foreach (var colors in repo.db.Stocks.Include(x => x.Color).Where(x => x.ProductID == item.ProductId && x.SizeID == 38))
                    {
                        item.ColorName.Add(colors.Color.ColorImg + ".jpg");
                    }
                }

                Session["ProductModel"] = result;
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

            foreach (var item in ProductsVM)
            {
                for (int i = 0; i < item.ColorName.Count; i++)
                {
                    item.ColorName[i] += ".jpg";
                }
            }
            return View(ProductsVM);

        }





    }
}