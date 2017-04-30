using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CobaltApp.Models
{
    public class ClusterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IPAdress { get; set; }
        public string SubnetMask { get; set; }
        public string Subnetwork { get; set; }

        //public virtual ICollection<ServerViewModel> ServersVMList { get; set; }
    }
}