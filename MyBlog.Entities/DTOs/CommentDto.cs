using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsActive { get; set; }

        public PostCommentDto PostCommentDto { get; set; }
        public UserCommentDto UserCommentDto { get; set; }
    }
}
