using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;

namespace ITSystem.Repositories
{
    public class UsedTechnologyRepository: BaseRepository<UsedTechnology>
    {
        public UsedTechnologyRepository() : base() { }
        public UsedTechnologyRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}