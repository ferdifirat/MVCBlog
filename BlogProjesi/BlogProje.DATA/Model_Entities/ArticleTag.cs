using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
   public class ArticleTag
    {
        public int ArticleTagID { get; set; }
        public int ArticleID { get; set; }
        public int TagID { get; set; }

        public virtual Article EtiketinMakalesi { get; set; }
        public virtual Tag MakaleninEtiketi { get; set; }

    }
}
