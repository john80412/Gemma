using Gemma.Models;
using Gemma.ViewModel;
using PagedList;
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

        public List<MemberCenter> GetInitialHomeView() =>
        new List<MemberCenter>
        {
            new MemberCenter{Item = "会員情報の編集", ItemDesciption = "Eメール、パスワード、配送・注文者情報やその他の会員情報の変更", NextUrl = "/MemberCenter/MemberInfo"},
            new MemberCenter{Item = "注文", ItemDesciption = "注文検索", NextUrl = "/MemberCenter/OrderSearch"},
            new MemberCenter{Item = "BOOKMARK", ItemDesciption = "BOOKMARK一覧へ", NextUrl = "#"},
        };


        /// <summary>
        /// 找到 User 資料庫的 id 資料，也可以改抓Email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AspNetUser GetMemberData(string Id) => db.AspNetUsers.Find(Id);

        public List<OrderViewModel> GetSearchStock(string customerName)
        {
            var orders = db.Database.SqlQuery<OrderViewModel>("exec OrderViewModel").AsQueryable();
            orders = !string.IsNullOrEmpty(customerName) ? orders.Where(x => x.CustomerName.ToUpper().Contains(customerName.ToUpper())) : orders;
            var results = orders.OrderBy(x => x.OrderID).ToList();
            return results;
        }
    }
}