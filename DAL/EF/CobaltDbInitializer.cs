using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class CobaltDbInitializer: DropCreateDatabaseAlways<CobaltContext>
    {
        protected override void Seed(CobaltContext context)
        {
            context.UserAccounts.Add(new UserAccount {Name = "admin", HashOfPassword = "123456"});
            context.UserAccounts.Add(new UserAccount {Name = "sam", HashOfPassword = "123456" });

            context.Servers.Add(new Server {Adress = "192.168.20.000", SubnetMask = "255.255.255.0", Subnet = "192.168.20.0/4"});

            context.Clusters.Add(new Cluster { Adress = "192.168.20.000", SubnetMask = "255.255.255.0", Subnet = "192.168.20.0/4" });

            base.Seed(context);
        }
    }
}
