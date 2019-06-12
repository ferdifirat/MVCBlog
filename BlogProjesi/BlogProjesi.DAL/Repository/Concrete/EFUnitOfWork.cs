using BlogProjesi.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjesi.DAL.Repository.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private bool disposed = false;

        public EFUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        ~EFUnitOfWork()
        {

        }
        public void Dispose()
        {
            //IDisposible'dan kalıtılan IUnitOfWork interface'sinden gelen Dispose metodu, işlem yapıldıktan sonra, oluşturulan context'i ram'den siler. Genelde crud işlemlerinden sonra kullanılır.
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            //Instance alındığı zaman hangi entity verildiyse o entity için generic yapılar ayarlanır ve bu yapıda repository döndürülür.
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Exception olarak gelen ex mesajı direkt olarak kullanıcıya bildirilmiş olur. Stacktrace yapısı bozulmadan ileti yollanmış olur.
                throw ex;
            }
        }
    }
}
