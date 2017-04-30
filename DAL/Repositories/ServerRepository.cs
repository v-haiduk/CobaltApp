using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    /// <summary>
    /// The implementation of ServerRepository
    /// </summary>
    public class ServerRepository : IServerRepository
    {
        private CobaltContext db;
        //private readonly DbSet<Server> _dbSet;

        public ServerRepository(CobaltContext context)
        {
            this.db = context;
           //_dbSet = db.Set<Server>();
        }

        public IEnumerable<Server> GetAllElements()
        {
            return db.Servers;
        }


        public Server GetElement(int id)
        {
            //return _dbSet.FirstOrDefault(serv=> serv.Id == id);
            return db.Servers.Find(id);
        }

        public IEnumerable<Server> FindElement(Func<Server, bool> predicate)
        {
            return db.Servers.Where(predicate);
        }

        public void Create(Server item)
        {
            db.Servers.Add(item);
        }

        public void Update(Server item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var serverForDelete = db.Servers.Find(id);
            if (serverForDelete != null)
            {
                db.Servers.Remove(serverForDelete);
            }
        }

    }
}
