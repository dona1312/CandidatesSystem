using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ITSystem.Repositories
{
    public class BaseRepository<T> where T: BaseModel
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;
        protected UnitOfWork unitOfWork;

        public BaseRepository()
        {
            this.context = new ITSystemContext();
            this.dbSet = this.context.Set<T>();
        }
        public BaseRepository(UnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
            this.context = unitOfWork.Context;
            this.dbSet = this.context.Set<T>();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {            
            IQueryable<T> result = dbSet;
            if (filter != null)
                return result.Where(filter).ToList();
            else
                return result.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Save(T item)
        {
            if (item.Id == 0)
                Insert(item);
            else
                Update(item);
            this.context.SaveChanges();
        }

        private void Insert(T item)
        {
            this.dbSet.Add(item);
        }

        private void Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            this.dbSet.Remove(GetById(id));
            this.context.SaveChanges();
        }
    }
}