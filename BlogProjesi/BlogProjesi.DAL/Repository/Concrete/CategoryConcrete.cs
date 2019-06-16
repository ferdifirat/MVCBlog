using BlogProje.DATA.Model_Entities;
using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class CategoryConcrete
    {
            public IRepository<Category> _categoryRepository;
            public IUnitOfWork _categoryUnitOfWork;
            private Context _dbContext;

            public CategoryConcrete()
            {
                _dbContext = new Context();
            _categoryUnitOfWork = new EFUnitOfWork(_dbContext);
            _categoryRepository = _categoryUnitOfWork.GetRepository<Category>();
            }
        }
    
}
