using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.Models
{
    /// <summary>
    /// OrderSearch - MemberCenter
    /// </summary>
    [MetadataType(typeof(OrderMD))]
    public partial class Order
    {
        public class OrderMD
        {

            [Display(Name = "ID")]
            public int OrderID { get; set; }

            [Display(Name = "お客様")]
            public string CustomerID { get; set; }

            [Display(Name = "日時")]
            [DataType(DataType.Date)]
            public DateTime OrderDate { get; set; }

            [Display(Name = "合計")]
            [DataType(DataType.Currency)]
            public int Total { get; set; }
        }
    }
}