using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.DTOs
{
    public class UserCommentDto
    {
        public string Id { get; set; }
        public string CitizenshipNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
    }
}
