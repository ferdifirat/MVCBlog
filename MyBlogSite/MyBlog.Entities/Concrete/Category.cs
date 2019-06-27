using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string PictureUrl { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
