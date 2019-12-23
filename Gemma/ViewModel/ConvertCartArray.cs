using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class ConvertCartArray
    {
        public List<int> ProductID { get; set; }
        public List<int> ColorID { get; set; }
        public List<int> SizeID { get; set; }

        public List<int> Quantity { get; set; }
        public List<decimal> Price { get; set; }


    }
}