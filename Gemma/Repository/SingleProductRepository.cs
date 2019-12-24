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
        public SingleProductDetailViewModel GetSingleDetails(int? productId)
        {
            var SingleProduct = db.Database.SqlQuery<SingleProductViewModel>("exec SingleProductViewModel").AsQueryable().Where(sp => sp.ProductId == productId).ToList();

            var ProductDetails = new SingleProductDetailViewModel()
            {
                ProductId = SingleProduct[0].ProductId,
                ProductName = SingleProduct[0].ProductName,
                Price = SingleProduct[0].UnitPrice,
                Description = SingleProduct[0].Explain.Replace("\n", "<br>"),
                CategoryName = SingleProduct[0].CategoryName,
                ColorDetails = new List<ProductColorDetails>()
            };

            foreach (var productColor in SingleProduct)
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