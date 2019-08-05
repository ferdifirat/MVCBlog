using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Entities.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string CitizenshipNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
