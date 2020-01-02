using System;
using System.Collections.Generic;
using System.Linq;
using Gemma.Models;
using System.Web;
using Gemma.ViewModel;
using System.Data.Entity;
using RestSharp;
using Newtonsoft.Json;

namespace Gemma.Repository
{
    public class CheckoutRepository
    {
        private readonly GemmaDBContext db = new GemmaDBContext();

        public List<CartViewModel> ConvertList(ConvertCartArray uncheckData)
        {
            List<CartViewModel> goodsInCart = new List<CartViewModel>();
            for (int i = 0; i < uncheckData.ColorID.Count; i++)
            {
                CartViewModel dataConvert = new CartViewModel
                {
                    ProductID = uncheckData.ProductID[i],
                    ProductName = db.Products.Find(uncheckData.ProductID[i]).ProductName,
                    SizeID = uncheckData.SizeID[i],
                    Size = db.Sizes.Find(uncheckData.SizeID[i]).Length,
                    ColorID = uncheckData.ColorID[i],
                    ColorName = db.Colors.Find(uncheckData.ColorID[i]).ColorName,
                    Quantity = uncheckData.Quantity[i],
                    Price = uncheckData.Price[i],
                    Discount = 0
                };
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
        public string CallLinePay(Line data)
        {
            var client = new RestClient("https://sandbox-api-pay.line.me/v2/payments/request");
            client.Timeout = -1;
            var request = RestPostMethod(data);
            IRestResponse response = client.Execute(request);
            LineConfirm confirm = new LineConfirm
            {
                amount = data.amount,
                currency = data.currency
            };
            HttpContext.Current.Session["confirm"] = confirm;
            var result = JsonConvert.DeserializeObject<LineRootObject>(response.Content);
            var transactionId = result.info.transactionId;
            HttpContext.Current.Session["transactionId"] = transactionId;
            return response.Content;
        }
        public void FinishLinePay()
        {
            var transactionId = HttpContext.Current.Session["transactionId"].ToString();
            var confirm = (LineConfirm)HttpContext.Current.Session["confirm"];
            var client = new RestClient("https://sandbox-api-pay.line.me/v2/payments/" + transactionId + "/confirm");
            client.Timeout = -1;
            var request = RestPostMethod(confirm);
            IRestResponse response = client.Execute(request);
            HttpContext.Current.Session["confirm"] = null;
            HttpContext.Current.Session["transactionId"] = null;
            //return response.Content;
        }
        private RestRequest RestPostMethod(object data)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("X-LINE-ChannelId", "1653703837");
            request.AddHeader("X-LINE-ChannelSecret", "6b3f7b69fe77cf38872dd80d7b9a8512");
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            return request;
        }
    }
}