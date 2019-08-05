using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.DTOs
{
   public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } //başlık
        public string Summary { get; set; }
        public string Content { get; set; } //içerik
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; } //oluşturma tarihi
        public int CategoryId { get; set; }
        public int ReadCount { get; set; } //okunma sayısı
        public int Voting { get; set; } //oylama
        public bool IsActive { get; set; }

        public PostsUserDto PostsUser { get; set; }
        public CategoryDto Category { get; set; }
    }
}
