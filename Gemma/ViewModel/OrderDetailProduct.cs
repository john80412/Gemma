using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class OrderDetailProduct
    {
        [Display(Name = "產品")]
        public string ProductName { get; set; }
        [Display(Name = "顏色")]
        public string ColorName { get; set; }
        [Display(Name = "尺寸")]
        public int SizeID { get; set; }
        [Display(Name = "單價")]
        public int UnitPrice { get; set; }
        [Display(Name = "折扣")]
        public decimal Discount { get; set; }
        [Display(Name = "數量")]
        public int Quantity { get; set; }
        [Display(Name = "小計")]
        public decimal TotalPrice { get; set; }
    }
}