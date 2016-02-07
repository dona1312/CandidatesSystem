using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Models
{
    public class Note:BaseModel
    {
        public int ConsultantId { get; set; }
        public int CandidateId { get; set; }
        public string Content { get; set; }
        public virtual Consultant Consultant { get; set; }
    }
}