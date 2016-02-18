using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITSystem.Models;

namespace ITSystem.Repositories
{
    public class ProgrammingLanguageRepository : BaseRepository<ProgrammingLanguage>
    {
        public ProgrammingLanguageRepository(ITSystemContext context)
            : base(context) { }
    }
}