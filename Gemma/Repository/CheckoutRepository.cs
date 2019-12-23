using System;
using System.Collections.Generic;
using System.Linq;
using Gemma.Models;
using System.Web;
using Gemma.ViewModel;
using System.Data.Entity;

namespace Gemma.Repository
{
    public class CheckoutRepository
    {
        private GemmaDBContext db = new GemmaDBContext();

        public List<CartViewModel> ConvertList(ConvertCartArray uncheckData)
        {
            List<CartViewModel> goodsInCart = new List<CartViewModel>();
            for (int i = 0; i < uncheckData.ColorID.Count; i++)
            {
                CartViewModel dataConvert = new CartViewModel();
                dataConvert.ProductID = uncheckData.ProductID[i];
                dataConvert.ProductName = db.Products.Find(uncheckData.ProductID[i]).ProductName;
                dataConvert.SizeID = uncheckData.SizeID[i];
                dataConvert.Size = db.Sizes.Find(uncheckData.SizeID[i]).Length;
                dataConvert.ColorID = uncheckData.ColorID[i];
                dataConvert.ColorName = db.Colors.Find(uncheckData.ColorID[i]).ColorName;
                dataConvert.Quantity = uncheckData.Quantity[i];
                dataConvert.Price = uncheckData.Price[i];
                dataConvert.Discount = 0;
                goodsInCart.Add(dataConvert);
            }
            return goodsInCart;
        }
        public CheckMemberInfoViewModel GetMemberData(string Id)
        {
            AspNetUser member = db.AspNetUsers.Find(Id);
            CheckMemberInfoViewModel subtitute = new CheckMemberInfoViewModel
            {
                LastName = member.LastName,
                FirstName = member.FirstName,
                Mobile = member.Mobile,
                Country = member.Country,
                PostalCode = member.PostalCode,
                Address = member.Address
            };
            return subtitute;
        }
        /// <summary>
        /// 測試會不會有使原表有null
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public void InfoToAspNetUser(CheckMemberInfoViewModel data, string Id)
        {
            //var member = from s in db.AspNetUsers.Where(x => x.Id == Id)
            //             select new AspNetUser
            //             {
            //                 LastName = data.LastName,
            //                 FirstName = data.FirstName,
            //                 Mobile = data.Mobile,
            //                 Address = data.Address,
            //                 PostalCode = data.PostalCode,
            //                 Country = data.Country,
            //             };

            AspNetUser member = db.AspNetUsers.Find(Id);
            member.LastName = data.LastName;
            member.FirstName = data.FirstName;
            member.Mobile = data.Mobile;
            member.Address = data.Address;
            member.PostalCode = data.PostalCode;
            member.Country = data.Country;
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void SaveOrder(List<CartViewModel> putInOrder, string userId)
        {
            var orderModel = new Order
            {
                CustomerID = userId,
                OrderDate = DateTime.Now
            };
            db.Orders.Add(orderModel);
            db.SaveChanges();
            foreach (var detail in putInOrder)
            {
                var orderDetailModel = new OrderDetail
                {
                    OrderID = db.Orders.Where((x) => x.CustomerID == userId).ToList().LastOrDefault().OrderID,
                    ProductID = detail.ProductID,
                    ColorID = detail.ColorID,
                    Quantity = detail.Quantity,
                    Discount = detail.Discount,
                    UnitPrice = (int)detail.Price,
                    SizeID = detail.SizeID
                };
                db.OrderDetails.Add(orderDetailModel);
            }
            var x = db.OrderDetails.ToList();
            // 清除購物車
            var cart = db.ShoppingCarts.Where((x) => x.CustomerID == userId);
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    db.ShoppingCarts.Remove(item);
                }
            }
            db.SaveChanges();
            HttpContext.Current.Session["Cart"] = null;
            HttpContext.Current.Session["CartItemCount"] = null;
            HttpContext.Current.Session["CartView"] = null;
        }

        public void AddCartBeforeLogoff(string userId)
        {
            if (HttpContext.Current.Session["Cart"] != null)
            {
                var db = new GemmaDBContext();
                foreach (var item in (List<Cart>)HttpContext.Current.Session["Cart"])
                {
                    ShoppingCart shoppingCart = new ShoppingCart
                    {
                        CustomerID = userId,
                        ProductID = item.ProductID,
                        ColorID = item.ColorID,
                        Quantity = item.Quantity,
                        SizeID = item.SizeID,
                    };
                    db.ShoppingCarts.Add(shoppingCart);
                }
                db.SaveChanges();
            }
        }
    }
}