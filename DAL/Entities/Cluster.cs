using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    /// <summary>
    /// The model of user for storage in the DB.
    /// </summary>
    public class Cluster
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IPAdress { get; set; }
        [Required]
        public string SubnetMask { get; set; }
        [Required]
        public string Subnetwork { get; set; }

        public virtual ICollection<Server> Servers { get; set; }
    }
}
