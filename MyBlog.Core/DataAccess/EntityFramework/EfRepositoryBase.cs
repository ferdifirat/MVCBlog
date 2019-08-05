using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            var activeEntity = _dbSet.Add(entity);
            activeEntity.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var activeEntity = _context.Entry(entity);
            activeEntity.State = EntityState.Deleted;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> condition)
        {
            return _context.Set<TEntity>().FirstOrDefault(condition);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> condition = null)
        {
            var list = condition == null ?
                _context.Set<TEntity>().ToList() :
                _context.Set<TEntity>().Where(condition).ToList();

            return list;
        }

        public void Update(TEntity entity)
        {
            var activeEntity = _context.Entry(entity);
            activeEntity.State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
