using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMohinh.Models.AccountViewModels
{
    public class LoginViewModel
    {
        //[Required]
        [EmailAddress]
        public string Email { get; set; } // cho phép người dùng Login bằng Email ( những email phải là duy nhất) 

        [Required(ErrorMessage = "Bắt buộc nhập mật khẩu!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập username!")]
        public string UserName { get; set; }
    }
}
