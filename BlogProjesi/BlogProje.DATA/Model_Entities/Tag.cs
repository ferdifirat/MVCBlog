using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
    //Etiket
   public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }

        public virtual List<ArticleTag> EtiketinMakalesi { get; set; }

    }
}
