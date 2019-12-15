using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class OnlineStoreStoredProcedureVM
    {
        public int ProductID { get; set; }
        public string ImageName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ColorName { get; set; }
        public string CategoryName { get; set; }
        public string Explain { get; set; }
        public int ColorID { get; set; }
    }
}