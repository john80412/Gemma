using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Models
{
    public class CartFromDetail
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ColorID { get; set; } 
        public int SizeID { get; set; }

        public int Count { get; set; }
        public decimal Price { get; set; }

        
    }
}