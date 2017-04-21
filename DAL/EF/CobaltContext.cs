using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;


namespace DAL.EF
{
    public class CobaltContext: DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<Cluster> Clusters { get; set; }

        public CobaltContext() :base("CobaltContext") { }
    }
}
