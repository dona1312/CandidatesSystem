using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.ViewModels.Candidates
{
    public class CandidateEditVM
    {
        public  int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<string> UsedTechnologies { get; set; }
        public List<string> ProgrammingLanguages { get; set; }
        public string Email { get; set; }
        public List<Note> Notes { get; set; }
    }
}