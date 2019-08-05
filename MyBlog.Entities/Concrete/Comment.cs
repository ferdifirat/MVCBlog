using MyBlog.Core.Entities;
using MyBlog.Entities.Concrete.CustomIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; } 
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
        public virtual CustomIdentityUser AspNetUsers { get; set; }
    }
}
