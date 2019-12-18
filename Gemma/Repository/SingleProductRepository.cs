using Gemma.Models;
using Gemma.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Gemma.Repository
{
    public class SingleProductRepository
    {
        public GemmaDBContext db = new GemmaDBContext();

        public IQueryable<SingleProductViewModel> Product { get => GetResult(); }


        public IQueryable<SingleProductViewModel> GetResult()
        {

            return from p in db.Products
                   join s in db.Stocks on p.ProductID equals s.ProductID
                   join c in db.Categories on p.CategoryID equals c.CategoryID
                   select new SingleProductViewModel
                   {
                       ProductId = p.ProductID,
                       ProductName = p.ProductName,
                       UnitPrice = p.UnitPrice,
                       CategoryName = c.CategoryName
                   };
        }
        public IEnumerable<SingleProductViewModel> GetAllProducts() => Product;
        public SingleProductDetailViewModel GetSingleDetails(int? productId)
        {
            var SingleProduct = db.Database.SqlQuery<SingleProductViewModel>("exec SingleProductViewModel").AsQueryable().Where(sp => sp.ProductId == productId).ToList()[0];

            var ProductDetails = new SingleProductDetailViewModel()
            {
                ProductId = SingleProduct.ProductId,
                ProductName = SingleProduct.ProductName,
                Price = SingleProduct.UnitPrice,
                Description = SingleProduct.Explain.Replace("\n", "<br>"),
                CategoryName = SingleProduct.CategoryName,
                ColorDetails = new List<ProductColorDetails>()
            };

            foreach (var productColor in db.Database.SqlQuery<SingleProductViewModel>("exec SingleProductViewModel").AsQueryable().Where(pc => pc.ProductId == productId))
            {
                ProductDetails.ColorDetails.Add(new ProductColorDetails()
                {
                    ColorId = productColor.ColorId,
                    ColorName = productColor.ColorName,
                    ImageName = productColor.ImageName
                });
            };

            return ProductDetails;
        }

        public List<ProductSizeDetails> GetProductSizes(int? productId, int? colorId)
        {
            List<ProductSizeDetails> pSizeDetails = new List<ProductSizeDetails>();
            
            foreach (var productSize  in db.Stocks.Where(ps => ps.ProductID == productId && ps.ColorID == colorId))
            {
                pSizeDetails.Add(new ProductSizeDetails(){ 
                 SizeId = productSize.SizeID,
                 Quantity = productSize.Quantity
                });
            }

            return pSizeDetails;
        }



    }
}