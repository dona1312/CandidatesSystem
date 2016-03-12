using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;

namespace ITSystem.ViewModels.Consultants
{
    public class ConsultantListVM : ListVM
    {
        public List<Consultant> Consultants { get; set; }
    }
}