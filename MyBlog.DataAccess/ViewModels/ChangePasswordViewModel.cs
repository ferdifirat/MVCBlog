using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
