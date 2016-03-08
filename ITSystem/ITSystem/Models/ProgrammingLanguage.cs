using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Models
{
    public class ProgrammingLanguage : BaseModel
    {
        public string Name { get; set; }
        public virtual List<Candidate> Candidate { get; set; }
    }
}