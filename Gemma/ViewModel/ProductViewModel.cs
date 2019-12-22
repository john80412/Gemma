using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class ProductViewModel
    {
        [Key]
        public int ProductID { get; set; }
        [Display (Name ="產品")]
        public string ProductName { get; set; }
        [Display(Name = "單價")]
        public int UnitPrice { get; set; }
        [Display(Name = "折扣")]
        public decimal Discount { get; set; }
        public int CategoryID { get; set; }
        [Display(Name = "說明")]
        public string Explain { get; set; }
        [Display(Name = "類別")]
        public string CategoryName { get; set; }
        [Display(Name = "圖片")]
        public string PictureUrl { get; set; }

    }
}