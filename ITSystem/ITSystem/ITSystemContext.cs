using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITSystem
{
    public class ITSystemContext : DbContext
    {
        public ITSystemContext() : base("ITSystem") { }

        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UsedTechnology> UsedTechnologies { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }


    }
}