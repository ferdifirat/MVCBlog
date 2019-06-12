using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
   public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Article> Articles { get; set; }
    }
}
