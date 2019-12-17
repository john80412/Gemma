using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Gemma.ViewModel;

namespace Gemma.Repository
{
    //改寫OnlineStoreProductVM相等之條件
    public class OnlineStoreProductVMCompare : IEqualityComparer<OnlineStoreProductVM>
    {
        public bool Equals(OnlineStoreProductVM x, OnlineStoreProductVM y)
        {
            return x.ProductId == y.ProductId;
        }

        public int GetHashCode(OnlineStoreProductVM obj)
        {
            return obj.ProductId.GetHashCode();
        }

    }
    public class OnlineStoreRepository 
    {
        internal GemmaDBContext db = new GemmaDBContext();
        public List<OnlineStoreProductVM> GetProductsSearch(string CategoryName, string ColorName, string OrderBy)
        {
            var StoredProcedureVM = db.Database.SqlQuery<SingleProductViewModel>("exec SingleProductViewModel");
            var ListProducts = (from p in StoredProcedureVM
                           select new OnlineStoreProductVM
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               UnitPrice = p.UnitPrice,
                               CategoryName = p.CategoryName
                           }).Distinct(new OnlineStoreProductVMCompare()).ToList();
            for (int i = 0; i < ListProducts.Count();i++)
            {
                ListProducts[i].ColorName = new List<string>();
                foreach (var item in StoredProcedureVM.Where(x => x.ProductId == ListProducts[i].ProductId))
                {
                    ListProducts[i].ColorName.Add(item.ColorName + ".jpg");
                }
            }
            var Products = ListProducts.AsQueryable();
            Products = CategoryName == "ALL" ? Products : Products.Where(x => x.CategoryName == CategoryName);
            Products = ColorName == "ALL" ? Products : Products.Where(x => x.ColorName.IndexOf(ColorName + ".jpg")>-1);
            switch (OrderBy)
            {
                case "LowToHigh":
                    Products = Products.OrderBy(x => x.UnitPrice);
                    break;
                case "HighToLow":
                    Products = Products.OrderByDescending(x => x.UnitPrice);
                    break;
            }
            return Products.ToList();
        }

    }
}