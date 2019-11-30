using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Gemma.Models.ShoppingCart;

namespace Gemma.Models
{
    [Serializable] //可序列化
    public class Cart //購物車類別
    {
        //建構值
        public Cart()
        {
            this.cartItems = new List<CartItemMD>();
        }

        //儲存所有商品
        public List<CartItemMD> cartItems;

        //取得商品總價
        public decimal TotalAmount
        {
            get 
            {
                decimal totalAmount = 0.0m;
                foreach(var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }
    }
}


