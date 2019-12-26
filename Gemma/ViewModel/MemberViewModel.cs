using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.ViewModel
{
    public class MemberViewModel
    {

        //[Display(Name = "身份證字號")]
        public string Id { get; set; }

        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }
        [Display(Name = "使用者信箱")]
        public string Email { get; set; }
        [Display(Name = "電話號碼")]
        public string PhoneNumber { get; set; }

        [Display(Name = "使用者地址")]

        public string Address { get; set; }
        //[Display(Name = "帳號解鎖日")]
        //public DateTime? LockoutEndDateUtc { get; set; }
        //[Display(Name = "登入失敗次數")]
        //public int AccessFailedCount { get; set; }
    }
}