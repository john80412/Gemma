using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gemma.Models
{
    public class AspNetUsers
    {
        public string Id { get; set; }
        [Display(Name ="信箱")]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        [Display(Name = "電話號碼")]
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [Display(Name = "帳號解鎖日")]
        public string LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        [Display(Name = "登入失敗次數")]
        public int AccessFailedCount { get; set; }
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }
    }
}