using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<SelectListItem> Categories{get; set;}
    }
}
