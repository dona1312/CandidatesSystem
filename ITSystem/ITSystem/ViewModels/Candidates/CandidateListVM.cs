using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;
using System.Web.Mvc;

namespace ITSystem.ViewModels.Candidates
{
    public class CandidateListVM
    {
        
        public List<Candidate> Candidates { get; set; }

        public string Search { get; set; }
    }
}