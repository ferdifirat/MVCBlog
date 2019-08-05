using MyBlog.Entities.Concrete;
using MyBlog.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DataAccess.ViewModels
{
    public class CommentsViewModel
    {
        public List<CommentDto> Comments{ get; set; }
        public CommentDto CommentDto { get; set; }
        public int PostId { get; set; }
    }
}
