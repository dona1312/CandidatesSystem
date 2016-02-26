using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>
    {
        public CandidateRepository(ITSystemContext context)
            : base(context) { }

        public CandidateRepository() : base() { }
    }
}