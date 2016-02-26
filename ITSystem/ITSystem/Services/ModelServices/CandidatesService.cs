using ITSystem.Models;
using ITSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Services.ModelServices
{
    public class CandidatesService : BaseService<Candidate>
    {
        public CandidatesService() : base() { }

        public List<Skill> GetCandidateSkills(int modelId)
        {
            return new SkillRepository().GetAll(s => s.CandidateId == modelId);
        }
    }
}