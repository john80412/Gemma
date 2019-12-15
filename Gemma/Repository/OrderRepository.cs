using Gemma.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;

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
        public OrderDetailViewModel GetOrderDetail(int? orderID)
        {
            var orders = db.Database.SqlQuery<OrderViewModel>("exec OrderViewModel").AsQueryable().Where(o => o.OrderID == orderID).ToList()[0];
            var orderDetails = new OrderDetailViewModel()
            {
                OrderID = orders.OrderID,
                CustomerName = orders.CustomerName,
                ProductNames = new List<OrderDetailProduct>(),
                TotalPrice = orders.TotalPrice,
                OrderDate = orders.OrderDate
            };
            foreach (var o in db.OrderDetails.Include(o => o.Product).Where(o => o.OrderID == orderID))
            {
                orderDetails.ProductNames.Add(new OrderDetailProduct()
                {
                    ProductName = o.Product.ProductName,
                    ColorName = db.Colors.Find(o.ColorID).ColorName,
                    SizeID = o.SizeID,
                    UnitPrice = o.UnitPrice,
                    Discount = o.Discount,
                    Quantity = o.Quantity,
                    TotalPrice = o.UnitPrice * (1 - o.Discount) * o.Quantity
                });
            }
            return orderDetails;
        }
        public string GetLastYearRevenuJson()
        {
            var orders = db.Database.SqlQuery<OrderViewModel>("exec OrderViewModel").AsQueryable().Where(o => o.OrderDate.Year == DateTime.Now.Year - 1);
            var revenu = new List<decimal>();
            for (int i = 1; i < 13; i++)
            {
                revenu.Add(orders.Where(o => o.OrderDate.Month == i).Sum(o => o.TotalPrice));
            }
            return Json.Encode(revenu);
        }
    }
}