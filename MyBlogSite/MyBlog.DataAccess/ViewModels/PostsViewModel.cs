﻿using MyBlog.Entities.Concrete;
using MyBlog.Entities.Concrete.CustomIdentity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; }
    }
}
