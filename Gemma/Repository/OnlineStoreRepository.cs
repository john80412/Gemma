using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Gemma.ViewModel;

namespace Gemma.Repository
{
    public class OnlineStoreRepository
    {
        internal GemmaDBContext db = new GemmaDBContext();


        // Category == ALL, Color == ALL
        public List<OnlineStoreProductVM> GetProductsAll()
        {
            List<OnlineStoreStoredProcedureVM> StoredProcedureVM = db.Database.SqlQuery<OnlineStoreStoredProcedureVM>("exec SingleProductViewModel").ToList();
            var Products = WhenCategoryChoose(StoredProcedureVM);
            return Products;
        }


        // Category == ???, Color == ALL
        public List<OnlineStoreProductVM> GetProductsWhenCategoryChoose(string CategoryName)
        {
            // 先將 預存程序 裡的資料 List出來，條件為 CategoryName == "BOOTS" (Id = 1~6)
            List<OnlineStoreStoredProcedureVM> StoredProcedureVM = db.Database.SqlQuery<OnlineStoreStoredProcedureVM>("exec SingleProductViewModel").Where(x => x.CategoryName == CategoryName).ToList();
            var Products = WhenCategoryChoose(StoredProcedureVM);
            return Products;
        }

        // Category == ALL, Color == ???
        public List<OnlineStoreProductVM> GetProductsWhenColorChoose(string ColorName)
        {
            // 先將 預存程序 裡的資料 List出來，條件為 ColorName == "BLACK" 
            List<OnlineStoreStoredProcedureVM> StoredProcedureVM = db.Database.SqlQuery<OnlineStoreStoredProcedureVM>("exec SingleProductViewModel").Where(x => x.ColorName == ColorName).ToList();
            var Products = WhenColorChoose(StoredProcedureVM);
            return Products;
        }

        // Category == ???, Color == ???
        public List<OnlineStoreProductVM> GetProductsWhenCategoryAndColorChoose(string CategoryName, string ColorName)
        {
            // 先將 預存程序 裡的資料 List出來，條件為, CategoryName == "BOOTS" , ColorName == "BLACK" 
            List<OnlineStoreStoredProcedureVM> StoredProcedureVM = db.Database.SqlQuery<OnlineStoreStoredProcedureVM>("exec SingleProductViewModel").Where(x => x.CategoryName == CategoryName && x.ColorName == ColorName).ToList();
            var Products = WhenColorChoose(StoredProcedureVM);
            return Products;
        }





        public List<OnlineStoreProductVM> WhenCategoryChoose(List<OnlineStoreStoredProcedureVM> StoredProcedureVM)
        {
            List<OnlineStoreProductVM> Products = new List<OnlineStoreProductVM>();
            OnlineStoreProductVM temp = new OnlineStoreProductVM();
            //temp.ColorName = new List<string>();

            // 取產品 第一個id 最後一個id
            OnlineStoreStoredProcedureVM First = StoredProcedureVM.FirstOrDefault();
            OnlineStoreStoredProcedureVM Last = StoredProcedureVM.LastOrDefault();
            int firstid = First.ProductID; int lastid = Last.ProductID;

            for (int i = firstid; i <= lastid; i++)
            {
                // 沒有 ProductId 10~12
                if (i == 10 || i == 11 || i == 12) { continue; }

                temp = new OnlineStoreProductVM();
                temp.ColorName = new List<string>();

                var ProductId = StoredProcedureVM.Where(x => x.ProductID == i).ToList();

                foreach (var item in ProductId)
                {
                    // temp.ColorName 代表 單一的 "MoreColorInProduct" Model，將同一個 ProductID 不同的顏色 加入 "MoreColorInProduct" 的 List<> 的 ColorName
                    temp.ColorName.Add(item.ColorName.ToString());
                    temp.ProductId = item.ProductID;
                    temp.ImageName = item.ImageName;
                    temp.ProductName = item.ProductName;
                    temp.UnitPrice = item.UnitPrice;
                    temp.CategoryName = item.CategoryName;
                }

                // 替換到 另一個ViewModel
                Products.Add(temp);
            }

            return Products;
        }


        public List<OnlineStoreProductVM> WhenColorChoose(List<OnlineStoreStoredProcedureVM> StoredProcedureVM)
        {
            List<OnlineStoreProductVM> Products = new List<OnlineStoreProductVM>();

            OnlineStoreProductVM temp = new OnlineStoreProductVM();
            //temp.ColorName = new List<string>();


            foreach (var item in StoredProcedureVM)
            {
                temp = new OnlineStoreProductVM();
                temp.ColorName = new List<string>();


                temp.ProductId = item.ProductID;
                temp.ImageName = item.ImageName;
                temp.ProductName = item.ProductName;
                temp.UnitPrice = item.UnitPrice;
                temp.CategoryName = item.CategoryName;


                var ProductId = db.Database.SqlQuery<OnlineStoreStoredProcedureVM>("exec SingleProductViewModel").Where(x => x.ProductID == temp.ProductId).ToList();

                foreach (var color in ProductId)
                {
                    //temp.ColorName 代表 單一的 "MoreColorInProduct" Model，將同一個 ProductID 不同的顏色 加入 "MoreColorInProduct" 的 List<> 的 ColorName
                    temp.ColorName.Add(color.ColorName.ToString());
                }

                Products.Add(temp);
            }

            return Products;
        }


    }
}