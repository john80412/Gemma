using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class CheckMemberInfoViewModel
    {
        [Display(Name = "姓")]
        [Required(ErrorMessage = "Required")]
        public string LastName { get; set; }

        [Display(Name = "名")]
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }

        [Display(Name = "電話番号")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Required")]
        public string Mobile { get; set; }

        [Display(Name = "国名")]
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }

        [Display(Name = "郵便番号")]
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Required")]
        public string PostalCode { get; set; }

        [Display(Name = "住所")]
        [Required(ErrorMessage = "Required")]
        public string Address { get; set; }
    }
}