using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Model_Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }

        public virtual List<ArticleTag> ArticleTags { get; set; }

    }
}
