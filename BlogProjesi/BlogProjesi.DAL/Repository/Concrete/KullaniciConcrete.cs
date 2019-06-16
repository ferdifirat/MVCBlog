using BlogProje.DATA.Model_Entities;
using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class KullaniciConcrete
    {
            public IRepository<Kullanici> _kullaniciRepository;
            public IUnitOfWork _kullaniciUnitOfWork;
            private Context _dbContext;

            public KullaniciConcrete()
            {
                _dbContext = new Context();
            _kullaniciUnitOfWork = new EFUnitOfWork(_dbContext);
            _kullaniciRepository = _kullaniciUnitOfWork.GetRepository<Kullanici>();
            }
        }
    
}
