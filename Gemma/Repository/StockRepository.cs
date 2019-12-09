using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace Gemma.Repository
{
    public class StockRepository
    {
        public GemmaDBContext db = new GemmaDBContext();
        public bool IsSuccess { get; set; }
        public IPagedList<StockViewModel> GetSearchStock(string productName, string colorName, string size, int page)
        {
            var stocks = from s in db.Stocks.Include(s => s.Color).Include(s => s.Product)
                         select new StockViewModel
                         {
                             ProductID = s.ProductID,
                             ProductName = s.Product.ProductName,
                             ColorID = s.ColorID,
                             ColorName = s.Color.ColorName,
                             SizeID = s.SizeID,
                             Quantity = s.Quantity
                         };
            int.TryParse(size, out var result);
            stocks = !string.IsNullOrEmpty(productName) ? stocks.Where(x => x.ProductName.ToUpper().Contains(productName.ToUpper())) : stocks;
            stocks = !string.IsNullOrEmpty(colorName) ? stocks.Where(x => x.ColorName.ToUpper().Contains(colorName.ToUpper())) : stocks;
            stocks = !string.IsNullOrEmpty(size) ? stocks.Where(x => x.SizeID == result) : stocks;
            var results = stocks.OrderBy(x => x.ProductID).ThenBy(x => x.ColorID).ThenBy(x => x.SizeID).ToPagedList(page, 10);
            return results;
        }
        public StockViewModel GetStockDetail(int? productID, int? colorID, int? sizeID)
        {
            var stocks = db.Stocks.Include(s => s.Color).Include(s => s.Product)
                        .Where(x => x.ProductID == productID && x.ColorID == colorID && x.SizeID == sizeID)
                        .ToList()[0];
            if (stocks == null)
            {
                return null;
            }
            var result = new StockViewModel
            {
                ProductID = stocks.ProductID,
                ProductName = stocks.Product.ProductName,
                ColorID = stocks.ColorID,
                ColorName = stocks.Color.ColorName,
                SizeID = stocks.SizeID,
                Quantity = stocks.Quantity
            };
            return result;
        }
        public void CreateStock(StockViewModel stock, HttpPostedFileBase[] files)
        {
            var result = db.Stocks.Find(stock.ProductID, stock.ColorID, stock.SizeID);
            if (result != null)
            {
                IsSuccess = false;
                return;
            }
            if (files.Length > 0)
            {
                var catagory = db.Categories.Find(db.Products.Find(stock.ProductID).CategoryID).CategoryName;
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}Assets/images/Product/{catagory}/{db.Products.Find(stock.ProductID).ProductName}/{db.Colors.Find(stock.ColorID).ColorImg}";
                var di = new DirectoryInfo(@path);
                if (!di.Exists)
                {
                    di.Create();
                }
                var quantity = di.GetFiles().Length;
                foreach (var file in files)
                {
                    file.SaveAs($"{path}/{++quantity}.jpg");
                }
            }
            IsSuccess = true;
            var data = new Stock
            {
                ProductID = stock.ProductID,
                ColorID = stock.ColorID,
                SizeID = stock.SizeID,
                Quantity = stock.Quantity,
                ImageName = $"{db.Products.Find(stock.ProductID).ProductName}/{db.Colors.Find(stock.ColorID).ColorImg}"
            };
            db.Stocks.Add(data);
            db.SaveChanges();
        }
        public void EditStock(StockViewModel stock)
        {
            var result = db.Stocks.Find(stock.ProductID, stock.ColorID, stock.SizeID);
            result.Quantity = stock.Quantity;
            db.Entry(result).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStock(int productID, int colorID, int sizeID)
        {
            var result = db.Stocks.Find(productID, colorID, sizeID);
            db.Stocks.Remove(result);
            db.SaveChanges();
            var results = db.Stocks.Where(x => x.ProductID == result.ProductID && x.ColorID == result.ColorID).ToList();
            if (results.Count == 0)
            {
                var catagory = db.Categories.Find(db.Products.Find(productID).CategoryID).CategoryName;
                var path = $"{AppDomain.CurrentDomain.BaseDirectory}Assets/images/Product/{catagory}/{db.Products.Find(productID).ProductName}/{db.Colors.Find(colorID).ColorImg}";
                var di = new DirectoryInfo(@path);
                di.Delete(true);
            }
        }
    }
}