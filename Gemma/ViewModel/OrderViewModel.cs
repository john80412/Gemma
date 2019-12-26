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
        [Display(Name ="#")]
        public int OrderID { get; set; }
        [Display(Name = "客戶名稱")]
        public string CustomerName { get; set; }
        [Display(Name = "產品名稱")]
        public string ProductNames { get; set; }
        [Display(Name = "總金額")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "訂單日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
    }
}