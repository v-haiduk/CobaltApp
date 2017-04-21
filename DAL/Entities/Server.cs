﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    /// <summary>
    /// The model of user for storage in the DB.
    /// </summary>
    public class Server
    {
        public int Id { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string SubnetMask { get; set; }
        [Required]
        public string Subnet { get; set; }

    }
}