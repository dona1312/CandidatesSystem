using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITSystem.Repositories
{
    public class UnitOfWork:IDisposable
    {
        public DbContext Context { get; private set; }
        private DbContextTransaction transaction = null;

        public UnitOfWork()
        {
            this.Context = new ITSystemContext();
            this.transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction != null)
            {
                this.transaction.Commit();
                this.transaction = null;
            }
        }

        public void RollBack()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction = null;
            }
        }

        public void Dispose()
        {
            Commit();
            Context.Dispose();
        }
    }
}