using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
    //Üye
    public class Member
    {
        public int MemberID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Photo { get; set; }

        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
