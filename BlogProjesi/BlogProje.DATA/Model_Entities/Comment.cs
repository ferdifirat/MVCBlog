using BlogProje.DATA.Identity_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
    //yorum
    public class Comment
    {
        public int CommentID { get; set; }
        public string Content { get; set; } //içerik
        public int MemberID { get; set; } //üyeıd
        public int ArticleID { get; set; } //makaleıd
        public DateTime CommentDate { get; set; } //yorumtarihi
        public bool IsActive { get; set; }

        public virtual Article Article { get; set; }
        public virtual Kullanici Kullanici { get; set; }

    }
}
