using Gemma.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Gemma.Repository
{
    public class OrderRepository
    {
        private GemmaDBContext db = new GemmaDBContext();
        public IPagedList<OrderViewModel> GetSearchStock(string customerName,string productNames, int page)
        {
            var orders = db.Database.SqlQuery<OrderViewModel>("exec OrderViewModel").AsQueryable();
            orders = !string.IsNullOrEmpty(customerName) ? orders.Where(x => x.CustomerName.ToUpper().Contains(customerName.ToUpper())): orders;
            orders = !string.IsNullOrEmpty(productNames) ? orders.Where(x => x.ProductNames.ToUpper().Contains(productNames.ToUpper())): orders;
            var results = orders.OrderBy(x => x.OrderID).ToPagedList(page, 10);
            return results;
        }
    }
}