using DAL.Repository.Abstract;
using DATA.Model_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Concrete
{
   public class ApplicationUserConcrete
    {

        public IRepository<ApplicationUser> _applicationUserRepository;
        public IUnitOfWork _applicationUserUnitOfWork;
        private Context _dbContext;

        public ApplicationUserConcrete()
        {
            _dbContext = new Context();
            _applicationUserUnitOfWork = new EFUnitOfWork(_dbContext);
            _applicationUserRepository = _applicationUserUnitOfWork.GetRepository<ApplicationUser>();
        }
    }
}
