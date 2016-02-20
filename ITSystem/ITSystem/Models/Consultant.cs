using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Enums;

namespace ITSystem.Models
{
    public class Consultant:BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RankEnum Rank  { get; set; }
        public virtual List<Candidate> Candidates { get; set; }
    }
}