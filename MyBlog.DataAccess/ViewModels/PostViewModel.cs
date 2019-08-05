using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class PostViewModel
    {
        public PostDto PostDto { get; set; }
        public List<SelectListItem> Categories{get; set;}
    }
}
