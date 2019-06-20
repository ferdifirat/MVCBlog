using DAL.Repository.Abstract;
using DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
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
