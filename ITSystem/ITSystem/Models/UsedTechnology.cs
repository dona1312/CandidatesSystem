using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Models
{
    public class UsedTechnology : BaseModel
    {
        public string Name { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}