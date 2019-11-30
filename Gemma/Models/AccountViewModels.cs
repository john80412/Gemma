using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System;

namespace Gemma.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "代碼")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "記住此瀏覽器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "Eメール *")]           // 電子郵件
        [Required(ErrorMessage = "Required field")]   // 驗證   ErrorMessage = "必填欄位"
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email format is incorrect")]     // 正則表達式  ErrorMessage = "電子郵件格式不正確"
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "パスワード *")]         // 密碼
        [Required(ErrorMessage = "Required field")]   // 驗證
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")] // 長度10, 最少輸入6個字   ErrorMessage = "密碼最少要6位"
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Must include numbers, English (at least one capital letter)")]   // ErrorMessage = "需為包含數字、英文(至少有一個大寫字母)"
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ログイン情報を記憶")]        // 記住我?
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "Eメール *")]             // 電子郵件
        [Required(ErrorMessage = "Required field")]     // 驗證 ErrorMessage = "必填欄位"
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email format is incorrect")]      // 正則表達式 ErrorMessage = "電子郵件格式不正確"
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "パスワード *")]         // 密碼
        [Required(ErrorMessage = "Required field")]   // 驗證 
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")] // 長度10, 最少輸入6個字  ErrorMessage = "密碼最少要6位"
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Must include numbers, English (at least one capital letter)")]   // ErrorMessage = "需為包含數字、英文(至少有一個大寫字母)"
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "パスワード（再入力） *")]        // 密碼(重新輸入)
        [Required(ErrorMessage = "Required field")]           // 驗證
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")] // 長度10, 最少輸入6個字  ErrorMessage = "密碼最少要6位"
        [Compare("Password", ErrorMessage = "Does not match the password")]  //比對密碼   ErrorMessage = "與密碼不符合")
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "生年月日 *")]
        [Required(ErrorMessage = "Required field")]   // 驗證
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "Eメール *")]           // 電子郵件
        [Required(ErrorMessage = "Required field")]   // 驗證
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "電子郵件格式不正確")]     // 正則表達式
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
