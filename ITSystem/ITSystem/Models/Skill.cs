using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Models
{
    public class Skill:BaseModel
    {
        public int CandidateId { get; set; }
        public int UsedTechnologyId { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual UsedTechnology UsedTechnology { get; set;}
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

    }
}