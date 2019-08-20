using System;
using System.Collections.Generic;
using System.Text;
using MyBlog.Entities.DTOs;

namespace MyBlog.DataAccess.ViewModels
{
    public class UsersViewModel
    {
        public List<UserDto> Users { get; set; }
    }
}
