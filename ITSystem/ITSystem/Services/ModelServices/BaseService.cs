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
        protected UnitOfWork unitOfWork;

        public BaseService()
        {
            unitOfWork = new UnitOfWork();
            baseRepo = new BaseRepository<T>(this.unitOfWork);
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
            try
            {
                this.unitOfWork.Commit();
            }
            catch (Exception)
            {
                this.unitOfWork.RollBack();
            }
        }

        public void Delete(T item)
        {
            baseRepo.Delete(item);
        }
    }
}