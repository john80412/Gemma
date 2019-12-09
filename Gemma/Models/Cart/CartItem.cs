using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.Models
{
    [MetadataType(typeof(CartItemMD))]
    public partial class ShoppingCart
    {
        public class CartItemMD
        {
            //商品編號
            public int ProductID { get; set; }

            //商品顏色
            public int ColorID { get; set; }

            //商品尺寸
            public int SizeID { get; set; }
            
            //---以上來自ShoppingCart
            
            //商品名稱
            public string Name { get; set; }

            //商品購買數量
            public int Quantity { get; set; }

            //商品購買時價格
            public decimal Price { get; set; }

            //商品小計
            public decimal Amount
            {
                get
                {
                    return this.Price * this.Quantity;
                }
            }
        }
    }
}

