using Gemma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Gemma.AspNetUser;

namespace Gemma.Repository
{
    public class MemberCenterRepository
    {
        internal GemmaDBContext db = new GemmaDBContext();
        /// <summary>
        /// 找到 User 資料庫的 id 資料，也可以改抓Email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AspNetUser GetMemberData(string Id)
        {
            AspNetUser member = db.AspNetUsers.Find(Id);
            return member;
        }

        /// <summary>
        /// 抓 User 的訂單
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrder(string Id)
        {
            var order = db.Orders.Where((d) => d.CustomerID == Id).ToList();
            return order;
        }
        //public decimal GetTotal(string Id)
        //{
        //    decimal total = 0;
        //    var totalList = db.OrderDetails.Where((d) => d.OrderID == db.Orders.Find(Id).OrderID).ToList();
        //    for(int i = 0; i < totalList.Count(); i++)
        //    {
        //        total += totalList[i].Quantity * totalList[i].UnitPrice * (1 - totalList[i].Discount);
        //    }
        //    return total;
        //}
    }
}