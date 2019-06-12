using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProje.DATA.Model_Entities
{
    //Yönetici
    public class Manager
    {
        public int ManagerID { get; set; }
        public int TC { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }

        public virtual User User { get; set; }
    }
}
