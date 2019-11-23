using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Gemma.Repository
{
    public class StockRepository
    {
        public GemmaDBContext db = new GemmaDBContext();
        public List<StockViewModel> GetAllStock()
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
            return stocks.ToList();
        }
        public List<StockViewModel> GetSearchStock(string productName, string colorName, string size)
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
            if (!string.IsNullOrEmpty(productName))
            {
                stocks = stocks.Where(x => x.ProductName.Contains(productName));
            }
            if (!string.IsNullOrEmpty(colorName))
            {
                stocks = stocks.Where(x => x.ColorName.Contains(colorName));
            }
            if (!string.IsNullOrEmpty(size))
            {
                var result = 0;
                int.TryParse(size,out result);
                stocks = stocks.Where(x => x.SizeID == result);
            }
            return stocks.ToList();
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
        public void CreateStock(StockViewModel stock)
        {
            var result = db.Stocks.Include(s => s.Color).Include(s => s.Product)
                        .Where(x => x.ProductID == stock.ProductID && x.ColorID == stock.ColorID && x.SizeID == stock.SizeID)
                        .ToList()[0];
            if (result != null)
            {
                return;
            }
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
        }
    }
}