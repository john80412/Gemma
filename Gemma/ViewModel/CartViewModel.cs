using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class CartViewModel
    {
        public string CartID { get; set; }
        //商品編號
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string ColorImg { get; set; }
        public int SizeID { get; set;}
        public decimal Size { get; set; }
        public decimal Discount { get; set; }
        //商品購買數量
        public int Quantity { get; set; }

        //商品購買時價格
        public decimal Price { get; set; }
        public decimal Amount
        {
            get
            {
                return this.Price * this.Quantity;
            }
        }
        public decimal AmountwithTax
        {
            get
            {
                return this.Price * this.Quantity * (decimal)1.05;
            }
        }
    }
}