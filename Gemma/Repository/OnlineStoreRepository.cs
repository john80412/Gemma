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
        public bool Equals(OnlineStoreProductVM x, OnlineStoreProductVM y) =>  x.ProductId == y.ProductId;
        public int GetHashCode(OnlineStoreProductVM obj) => obj.ProductId.GetHashCode();
    }
    public class OnlineStoreRepository 
    {
        internal GemmaDBContext db = new GemmaDBContext();
        public List<OnlineStoreProductVM> GetProductsSearch(string CategoryName, string ColorName, string OrderBy,IQueryable<OnlineStoreProductVM> Products)
        {
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
        public List<OnlineStoreProductVM> GetProducts()
        {
            var StoredProcedureVM = db.Database.SqlQuery<SingleProductViewModel>("exec SingleProductViewModel").AsQueryable();
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
            return ListProducts;
        }

    }
}