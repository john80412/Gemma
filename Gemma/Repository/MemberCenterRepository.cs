using Gemma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Gemma.Models.AspNetUser;

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
        public AspNetUser GetMemberData(string id)
        {
            AspNetUser member = db.AspNetUsers.Find(id);
            return member;
        }

        /// <summary>
        /// 抓 User 的訂單
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrder(string id)
        {
            var order = db.Orders.Where((d) => d.CustomerID == id).ToList();
            return order;
        }
    }
}