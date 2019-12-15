using Gemma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class SingleProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public string Explain { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ImageName { get; set; }

    }
}