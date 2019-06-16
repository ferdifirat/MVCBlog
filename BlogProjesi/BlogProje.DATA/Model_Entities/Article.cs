using BlogProje.DATA.Identity_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
    //Makale
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; } //başlık
        public string Content { get; set; } //içerik
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; } //oluşturma tarihi
        public int CategoryID { get; set; }
        public int MemberID { get; set; } //üyeID
        public int ReadCount { get; set; } //okunma sayısı
        public int Voting { get; set; } //oylama
        public bool IsActive { get; set; }


        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }      
        public virtual Kullanici Kullanici { get; set; }
        public virtual List<ArticleTag> ArticleTags { get; set; }
    }
}
