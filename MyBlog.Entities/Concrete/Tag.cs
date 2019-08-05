using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.Concrete
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual List<PostTag> PostTags { get; set; }

    }
}
