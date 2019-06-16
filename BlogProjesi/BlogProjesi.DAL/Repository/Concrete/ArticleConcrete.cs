using BlogProje.DATA.Model_Entities;
using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class ArticleConcrete
    {
            public IRepository<Article> _articleRepository;
            public IUnitOfWork _articleUnitOfWork;
            private Context _dbContext;

            public ArticleConcrete()
            {
                _dbContext = new Context();
                _articleUnitOfWork = new EFUnitOfWork(_dbContext);
                _articleRepository = _articleUnitOfWork.GetRepository<Article>();
            }
        }
    
}
