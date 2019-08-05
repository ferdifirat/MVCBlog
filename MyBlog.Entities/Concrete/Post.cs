using MyBlog.Core.Entities;
using MyBlog.Entities.Concrete.CustomIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyBlog.Entities.Concrete
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } //başlık
        public string Summary { get; set; }
        public string Content { get; set; } //içerik
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; } //oluşturma tarihi
        public int CategoryId { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; } //üyeID
        public int ReadCount { get; set; } //okunma sayısı
        public int Voting { get; set; } //oylama
        public bool IsActive { get; set; }


        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual CustomIdentityUser AspNetUsers { get; set; }
        public virtual List<PostTag> PostTags { get; set; }
    }
}
