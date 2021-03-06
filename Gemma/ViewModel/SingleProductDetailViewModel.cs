﻿using Gemma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class SingleProductDetailViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<ProductColorDetails> ColorDetails { get; set; }
    }
}