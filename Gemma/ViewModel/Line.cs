using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class Line
    {
        public string productName { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string confirmUrl { get; set; }
        public string orderId { get; set; }
    }

    public class LineConfirm
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }
}