using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma
{
    [MetadataType(typeof(AspNetUserMD))]
    public partial class AspNetUser
    {
        public class AspNetUserMD
        {
            public string Id { get; set; }
            /// <summary>
            /// 登錄信息
            /// </summary>
            [Display(Name = "Eメール")]
            [DataType(DataType.EmailAddress)]
            [Required(ErrorMessage = "Required")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Error type")]
            public string Email { get; set; }

            [Display(Name = "パスワード")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Required")]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 digits")]
            public string Password { get; set; }

            [Display(Name = "パスワード（再入力")]
            [DataType(DataType.Password)]
            [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 digits")]
            [Required(ErrorMessage = "Required")]
            [Compare("Password", ErrorMessage = "Doesn't match the password")]
            public string CheckPassword { get; set; }
            /// <summary>
            /// 注文者住所
            /// </summary>
            [Display(Name = "姓")]
            [Required(ErrorMessage = "Required")]
            public string LastName { get; set; }

            [Display(Name = "名")]
            [Required(ErrorMessage = "Required")]
            public string FirstName { get; set; }

            [Display(Name = "電話番号 *")]
            [DataType(DataType.PhoneNumber)]
            [Required(ErrorMessage = "Required")]
            public string Mobile { get; set; }

            [Display(Name = "国名")]
            public string Country { get; set; }

            [Display(Name = "郵便番号")]
            [DataType(DataType.PostalCode)]
            public string PostalCode { get; set; }

            [Display(Name = "住所")]
            public string Address { get; set; }

            [Display(Name = "生年月日")]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "Required")]
            public DateTime? DateOfBirth { get; set; }
        }  
    }
}