using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CobaltApp.Models
{
    public class ServerViewModel
    {
        public int Id { get; set; }
        public string IPAdress { get; set; }
        public string SubnetMask { get; set; }
        public string Subnetwork { get; set; }

        public ClusterViewModel ClusterVM { get; set; }
    }
}