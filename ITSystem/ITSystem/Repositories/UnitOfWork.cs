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
        private ProgrammingLanguageRepository programmingRepo;
        private UsedTechnologyRepository techRepo;
        private SkillRepository skillRepo;
        private ITSystemContext context;
        
        public UnitOfWork()
        {
            this.context = new ITSystemContext();
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

        public ProgrammingLanguageRepository ProgrammingLanguageRepository
        {
            get
            {
                if (programmingRepo == null)
                {
                    programmingRepo = new ProgrammingLanguageRepository(context);
                }
                return programmingRepo;
            }
        }

        public UsedTechnologyRepository UsedTechnologyRepository
        {
            get
            {
                if (techRepo == null)
                {
                    techRepo = new UsedTechnologyRepository(context);
                }
                return techRepo;
            }
        }
        public SkillRepository SkillsRepository
        {
            get
            {
                if (skillRepo == null)
                {
                    skillRepo = new SkillRepository(context);
                }
                return skillRepo;
            }
        }
    }
}