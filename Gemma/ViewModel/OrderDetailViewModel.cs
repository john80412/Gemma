using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class OrderDetailViewModel
    {
        [Display(Name = "訂單編號")]
        public int OrderID { get; set; }
        [Display(Name = "客戶名稱")]
        public string CustomerName { get; set; }
        public List<OrderDetailProduct> ProductNames { get; set; }
        [Display(Name = "總計")]
        public decimal TotalPrice { get; set; }
        [Display(Name = "訂單日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

    }
}