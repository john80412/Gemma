using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Gemma.Models
{
    
    public class Cart //購物車類別
    {
        //建構值
        public int RecordID { get; set; }

        public string CartID { get; set; }
        //商品編號
        public int ProductID { get; set; }
 
        public int ColorID { get; set; }
        public int SizeID { get; set; }
        //商品購買數量
        public int Quantity { get; set; }

        //商品購買時價格
        public decimal Price { get; set; }

    }
}


