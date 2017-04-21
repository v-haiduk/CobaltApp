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
    /// The implementation of ClusterRepository
    /// </summary>
    public class ClusterRepository : IClusterRepository
    {
        private CobaltContext db;

        public ClusterRepository(CobaltContext context)
        {
            this.db = context;
        }
         
        public IEnumerable<Cluster> GetAllElements()
        {
            return db.Clusters;
        }

        public Cluster GetElement(int id)
        {
            return db.Clusters.Find(id);
        }

        public IEnumerable<Cluster> FindElement(Func<Cluster, bool> predicate)
        {
            return db.Clusters.Where(predicate);
        }

        public void Create(Cluster item)
        {
            db.Clusters.Add(item);
        }

        public void Update(Cluster item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var serverForDelete = db.Clusters.Find(id);
            if (serverForDelete != null)
            {
                db.Clusters.Remove(serverForDelete);
            }
        }
    }
}
