using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;
using System.Web.Mvc;
using ITSystem.Enums;

namespace ITSystem.ViewModels.Candidates
{
    public class CandidateListVM : ListVM
    {
        public List<Candidate> Candidates { get; set; }
        public SearchEnum SearchType { get; set; }
    }
}