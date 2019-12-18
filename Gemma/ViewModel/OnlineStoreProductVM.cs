using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class OnlineStoreProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public List<string> ColorName { get; set; }     // 需要在 Controller => new List<string>


        // 可能可以刪掉
        public string CategoryName { get; set; }
    }
}