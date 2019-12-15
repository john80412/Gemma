using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class OnlineStore
    {

        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public string Picture { get; set; }
        public string Heart { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public List<string> Color { get; set; }

        public string Brand { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Tax { get; set; }
    }
}