using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class OrderViewModel
    {
        [Key]
        [Display(Name ="訂單編號")]
        public int OrderID { get; set; }
        [Display(Name = "客戶名稱")]
        public string CustomerName { get; set; }
        [Display(Name = "產品名稱")]
        public string ProductNames { get; set; }
        [Display(Name = "總金額")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "訂單日期")]
        public DateTime OrderDate { get; set; }
    }
}