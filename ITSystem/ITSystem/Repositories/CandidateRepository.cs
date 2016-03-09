using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>
    {
        public CandidateRepository() : base() { }
        public CandidateRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}