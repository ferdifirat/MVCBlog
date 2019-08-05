using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels.HomePage
{
    public class CardViewModel
    {
        public List<CategoryDto> Categories { get; set; }

    }
}
