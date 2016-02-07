using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSystem.Repositories
{
    public class UnitOfWork
    {
        private ConsultantRepository consultantRepo;
        private CandidateRepository candidateRepo;
        private NoteRepository noteRepo;
        private ITSystemContext context;

        
        public UnitOfWork()
        {
            
        }

        public ConsultantRepository ConsultantRepository
        {
            get
            {
                if (consultantRepo == null)
                {
                    consultantRepo = new ConsultantRepository(context);
                }
                return consultantRepo;
            }
        }

        public CandidateRepository CandidateRepository
        {
            get
            {
                if (candidateRepo == null)
                {
                    candidateRepo = new CandidateRepository(context);
                }
                return candidateRepo;
            }
        }

        public NoteRepository NoteRepository
        {
            get
            {
                if (noteRepo == null)
                {
                    noteRepo = new NoteRepository(context);
                }
                return noteRepo;
            }
        }
    }
}