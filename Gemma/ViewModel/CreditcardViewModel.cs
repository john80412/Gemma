using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class CreditcardViewModel
    {
        //[CreditCard]
        [Display(Name = "カード番号")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"\d{16}", ErrorMessage = "Error type")]
        public decimal DigitName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "有効期限 (mm/yy)")]
        [RegularExpression(@"^(0[1-9])|(1[012])", ErrorMessage = "Error type")]
        public string Month { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Error type")]
        public decimal Year { get; set; }

        [Display(Name = "セキュリティコード")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Error type")]
        public decimal BackNum { get; set; } 
    }
}