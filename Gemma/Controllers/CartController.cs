using Gemma.Models;
using Gemma.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gemma.Controllers
{
    public class CartController : Controller
    {
        public GemmaDBContext db = new GemmaDBContext();
        // GET: Cart

        public ActionResult CartView()
        {
            return View();
        }
        public int  DetailToCartButton(CartFromDetail CFD)
        {
            List<Cart> cartItems = new List<Cart>();

            if (Session["Cart"] == null)
            {
                Cart cart = new Cart
                {
                    RecordID = 1,

                    CartID = Guid.NewGuid().ToString(),

                    ProductID = CFD.ProductID,
                    ColorID = CFD.ColorID,
                    SizeID = CFD.SizeID,
                    Quantity = CFD.Count,
                    Price =CFD.Price,

                };

                cartItems.Add(cart);

                Session["Cart"] = cartItems;
                Session["CartItemCount"] = cart.RecordID;
            }
            else
            {
                cartItems = (List<Cart>)Session["Cart"]; //將Session中的購物車記錄還原成集合

                Cart cart = new Cart
                {
                    RecordID = cartItems.Count() + 1,

                    ProductID = CFD.ProductID,
                    ColorID = CFD.ColorID,
                    SizeID =CFD.SizeID,
                    Quantity = CFD.Count,
                    Price = CFD.Price,

                };

                cartItems.Add(cart);

                Session["Cart"] = cartItems;
                Session["CartItemCount"] = cart.RecordID;
            }

            return cartItems.Count;
        }
        public ActionResult GetCart(CartFromDetail CFD)
        {
            List<CartViewModel> cartViewItems = new List<CartViewModel>();

            if (Session["CartView"] == null)
            {
                CartViewModel cart = new CartViewModel
                {
         

                    CartID = Guid.NewGuid().ToString(),


                    ProductID = CFD.ProductID,
                    ProductName = db.Products.Find(CFD.ProductID).ProductName,
                    CategoryName = db.Categories.Find(db.Products.Find(CFD.ProductID).CategoryID).CategoryName,
                    ColorID = CFD.ColorID,
                    SizeID = CFD.SizeID,
                    Size = db.Sizes.Find(CFD.SizeID).Length,
                    ColorName = db.Colors.Find(CFD.ColorID).ColorName,
                    ColorImg = db.Colors.Find(CFD.ColorID).ColorImg,
                    Quantity = CFD.Count,
                    Price = db.Products.Find(CFD.ProductID).UnitPrice

                };

                cartViewItems.Add(cart);

                Session["CartView"] = cartViewItems;
            }
            else
            {
                cartViewItems = (List<CartViewModel>)Session["CartView"]; //將Session中的購物車記錄還原成集合

                CartViewModel cart = new CartViewModel
                {
                   

                    ProductID = CFD.ProductID,
                    CartID = Guid.NewGuid().ToString(),
                    ProductName = db.Products.Find(CFD.ProductID).ProductName,
                    CategoryName = db.Categories.Find(db.Products.Find(CFD.ProductID).CategoryID).CategoryName,
                    ColorID = CFD.ColorID,
                    ColorName=db.Colors.Find(CFD.ColorID).ColorName,
                    ColorImg = db.Colors.Find(CFD.ColorID).ColorImg,
                    SizeID = CFD.SizeID,
                    Size = db.Sizes.Find(CFD.SizeID).Length,
                    Quantity = CFD.Count,
                    Price = db.Products.Find(CFD.ProductID).UnitPrice

                };

                cartViewItems.Add(cart);

                Session["CartView"] = cartViewItems;

            }
            var data = JsonConvert.SerializeObject(cartViewItems);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}