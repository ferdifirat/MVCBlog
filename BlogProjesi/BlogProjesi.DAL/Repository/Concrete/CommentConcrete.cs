using BlogProje.DATA.Model_Entities;
using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class CommentConcrete
    {
            public IRepository<Comment> _commentRepository;
            public IUnitOfWork _commentUnitOfWork;
            private Context _dbContext;

            public CommentConcrete()
            {
                _dbContext = new Context();
            _commentUnitOfWork = new EFUnitOfWork(_dbContext);
            _commentRepository = _commentUnitOfWork.GetRepository<Comment>();
            }
        }
    
}
