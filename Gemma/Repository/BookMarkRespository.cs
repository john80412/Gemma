using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gemma.Repository
{
    public class BookMarkRespository
    {
        internal GemmaDBContext db = new GemmaDBContext();

        public  List<BookMarkViewModel> GetBookMarkDetail(string Id) //viewmodel 取得類別名稱
        {
            var bookmarkview = new List<BookMarkViewModel>();
            var bookmark = db.BookMarks.Include(s => s.Product).Where(s => s.CustomerID == Id).ToList();
            foreach (var item in bookmark)
            {
                bookmarkview.Add(new BookMarkViewModel() { //item轉成bookemark類型
                    ProductName = item.Product.ProductName,
                    CategoryName = db.Categories.Find(item.Product.CategoryID).CategoryName,
                    UnitPrice=item.Product.UnitPrice
                });
            }
                return bookmarkview;
        }//product 和bookmark 連結foreign key

        internal void DeleteBookMark(string productName)
        {
            var result = db.BookMarks.Include(s => s.Product).Where(s => s.Product.ProductName == productName).ToList()[0];
            db.BookMarks.Remove(result);
            db.SaveChanges();
        }
    }
}