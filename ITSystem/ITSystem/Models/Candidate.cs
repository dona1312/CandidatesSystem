using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Models
{
    public class Candidate: BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public virtual List<Note> Notes { get; set; }
        public virtual List<Consultant> Consultants { get; set; }
        public virtual List<UsedTechnology> UsedTechnologies { get; set; }
        public virtual List<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}