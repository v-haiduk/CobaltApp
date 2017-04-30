using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        //private readonly DbContext db;
        private CobaltContext db;
        private UserAccountRepository userAccountRepository;
        private ServerRepository serverRepository;
        private ClusterRepository clusterRepository;

        //public EFUnitOfWork(DbContext db)
        //{
        //    this.db = db;
        //}
        public EFUnitOfWork()
        {
            db = new CobaltContext();
        }

        public IUserRepository UserRepository
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

        public IServerRepository ServerRepository
        {
            get
            {
                if (serverRepository == null)
                {
                    serverRepository = new ServerRepository(db);
                }
                return serverRepository;
            }
        }

        public IClusterRepository ClusterRepository
        {
            get
            {
                if (clusterRepository == null)
                {
                    clusterRepository = new ClusterRepository(db);
                }
                return clusterRepository;
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
