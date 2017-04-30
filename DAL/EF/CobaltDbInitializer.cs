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
            context.UserAccounts.Add(new UserAccount {Name = "jerry", HashOfPassword = "123456" });
            context.UserAccounts.Add(new UserAccount {Name = "tom", HashOfPassword = "123456" });

            var blue = new Cluster {Name = "Blue", IPAdress = "192.167.20.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4" };
            var white = new Cluster {Name = "White", IPAdress = "192.168.20.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4" };
            var black = new Cluster {Name = "Black", IPAdress = "192.169.20.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4" };
            context.Clusters.Add(blue);
            context.Clusters.Add(white);
            context.Clusters.Add(black);

            context.Servers.Add(new Server {IPAdress = "192.168.20.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = blue });
            context.Servers.Add(new Server {IPAdress = "192.168.21.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = blue });
            context.Servers.Add(new Server {IPAdress = "192.168.22.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = blue });
            context.Servers.Add(new Server {IPAdress = "192.168.23.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = white });
            context.Servers.Add(new Server {IPAdress = "192.168.24.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = white });
            context.Servers.Add(new Server {IPAdress = "192.168.25.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = white });
            context.Servers.Add(new Server {IPAdress = "192.168.26.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = white });
            context.Servers.Add(new Server {IPAdress = "192.168.27.000", SubnetMask = "255.255.255.0", Subnetwork = "192.168.20.0/4", Cluster = black });

            base.Seed(context);
        }
    }
}
