﻿using ITSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Repositories
{
    public class NoteRepository : BaseRepository<Note>
    {
        public NoteRepository(ITSystemContext context)
            : base(context) { }
    }
}