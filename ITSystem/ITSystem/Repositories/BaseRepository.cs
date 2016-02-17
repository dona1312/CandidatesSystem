using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ITSystem.Repositories
{
    public abstract class BaseRepository<T> where T: BaseModel
    {
        protected readonly ITSystemContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ITSystemContext context)
        {
            this.context = new ITSystemContext();
            this.dbSet = this.context.Set<T>();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {            
            IQueryable<T> result = dbSet;
            if (filter != null)
            {
                return result.Where(filter).ToList();
            }
            else
            {
                return result.ToList();
            }

        }
        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual void Save(T item)
        {
            if (item.Id <= 0)
            {
                Insert(item);
            }
            else
            {
                Update(item);
            }
        }

        private void Insert(T item)
        {
            this.dbSet.Add(item);
            this.context.SaveChanges();
        }

        private void Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(T item)
        {
            this.dbSet.Remove(item);
            this.context.SaveChanges();
        }
    }
}