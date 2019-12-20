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
        public ActionResult FindBrand(string CategoryName = "ALL", string ColorName = "ALL", string OrderBy = "None")
        {
            if (Session["ListProducts"] == null)
            {

                var StoredProcedureVM = repo.db.Database.SqlQuery<SingleProductViewModel>("exec SingleProductViewModel").AsQueryable();
                var ListProducts = (from p in StoredProcedureVM
                                    select new OnlineStoreProductVM
                                    {
                                        ProductId = p.ProductId,
                                        ProductName = p.ProductName,
                                        UnitPrice = p.UnitPrice,
                                        CategoryName = p.CategoryName
                                    }).Distinct(new OnlineStoreProductVMCompare()).ToList();
                foreach (var item in ListProducts)
                {
                    item.ColorName = new List<string>();
                    foreach (var color in StoredProcedureVM.Where(x => x.ProductId == item.ProductId))
                    {
                        item.ColorName.Add(color.ColorName + ".jpg");
                    }
                }
                Session["ListProducts"] = ListProducts;
            }
            Session["CategoryName"] = CategoryName;
            Session["ColorName"] = ColorName;
            Session["PriceOrderBy"] = OrderBy;
            var ProductVM = repo.GetProductsSearch(CategoryName, ColorName, OrderBy, ((List<OnlineStoreProductVM>)Session["ListProducts"]).AsQueryable());
            Session["ProductModel"] = ProductVM;
            return View(ProductVM);
        }
    }
}