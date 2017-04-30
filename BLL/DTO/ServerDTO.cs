﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data between layers
    /// </summary>
    public class ServerDTO
    {
        public int Id { get; set; }
        public string IPAdress { get; set; }
        public string SubnetMask { get; set; }
        public string Subnetwork { get; set; }

        public ClusterDTO ClusterDTO { get; set; }
    }
}
