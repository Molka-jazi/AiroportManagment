using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(DbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            dbSet.RemoveRange(dbSet.Where(where));
        }
        public TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return
           dbSet.Where(where).FirstOrDefault();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }
        public TEntity GetById(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            if (where != null)
                return dbSet.Where(where);
            else
                return dbSet.AsEnumerable();
        }


        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }


}
