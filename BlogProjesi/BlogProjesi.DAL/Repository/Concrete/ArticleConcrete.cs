using BlogProje.DATA.Model_Entities;
using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogProjesi.DAL.Context;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class ArticleConcrete : IArticle
    {
        public IRepository<Article> _articleRepository;
        public IUnitOfWork _articleUnitOfWork;
        private DbContext _dbContext;

        public ArticleConcrete()
        {
            _dbContext = new Context.Context();
            _articleUnitOfWork = new EFUnitOfWork(_dbContext);
            _articleRepository = _articleUnitOfWork.GetRepository<Article>();
        }
    }
}
