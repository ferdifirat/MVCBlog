using MyBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class CommentsViewModel
    {
        public List<Comment> Comments{ get; set; }
        public Comment Comment { get; set; }
        public int PostId { get; set; }
    }
}
