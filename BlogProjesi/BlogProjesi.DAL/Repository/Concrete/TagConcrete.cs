using BlogProje.DATA.Model_Entities;
using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class TagConcrete
    {
            public IRepository<Tag> _tagRepository;
            public IUnitOfWork _tagUnitOfWork;
            private Context _dbContext;

            public TagConcrete()
            {
                _dbContext = new Context();
            _tagUnitOfWork = new EFUnitOfWork(_dbContext);
            _tagRepository = _tagUnitOfWork.GetRepository<Tag>();
            }
        }
    
}
