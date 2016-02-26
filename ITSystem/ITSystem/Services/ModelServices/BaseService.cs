using ITSystem.Models;
using ITSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ITSystem.Services.ModelServices
{
    public class BaseService<T> where T : BaseModel, new()
    {
        private readonly BaseRepository<T> baseRepo;

        public BaseService()
        {
            baseRepo = new BaseRepository<T>();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return baseRepo.GetAll(filter);        
        }

        public T GetById(int id)
        {
            return baseRepo.GetById(id);
        }

        public void Save(T item)
        {
            baseRepo.Save(item);
        }

        public void Delete(T item)
        {
            baseRepo.Delete(item);
        }
    }
}