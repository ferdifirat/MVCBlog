using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Code { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
