using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    /// <summary>
    /// The class is needed, that all repositories use one context of data.
    /// Through this class, we will work with DB.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private CobaltContext db;
        private UserAccountRepository userAccountRepository;

        public EFUnitOfWork()
        {
            db = new CobaltContext();
        }

        public IUserRepository userRepositories
        {
            get
            {
                if (userAccountRepository == null)
                {
                    userAccountRepository = new UserAccountRepository(db);
                }
                return userAccountRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        //Implementation of combined template
        private bool disposed = false;

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
