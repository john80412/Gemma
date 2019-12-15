using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.Models
{
    public class CollectionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        [DisplayFormat(DataFormatString = "¥{0} + TAX", ApplyFormatInEditMode = false)]
        public int Price { get; set; }

        public string Weburl { get; set; }
    }
}