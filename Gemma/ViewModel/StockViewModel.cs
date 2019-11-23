using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class StockViewModel
    {
        public int ProductID { get; set; }
        [Display (Name ="產品名稱")]
        public string ProductName { get; set; }
        public int ColorID { get; set; }
        [Display(Name = "顏色名稱")]
        public string ColorName { get; set; }
        [Display(Name = "尺寸")]
        public int SizeID { get; set; }
        [Display(Name = "庫存數量")]
        public int Quantity { get; set; }
    }
}