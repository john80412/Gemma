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
            CategoryName ??= "ALL";
            ColorName ??= "ALL";
            OrderBy ??= "None";
            Session["CategoryName"] = CategoryName;
            Session["ColorName"] = ColorName;
            Session["PriceOrderBy"] = OrderBy;
            var ProductVM = repo.GetProductsSearch(CategoryName, ColorName, OrderBy);
            Session["ProductModel"] = ProductVM;
            return View(ProductVM);
        }
    }
}