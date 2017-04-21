using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CobaltApp.Models
{
    public class ClusterViewModel
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string SubnetMask { get; set; }
        public string Subnet { get; set; }
    }
}