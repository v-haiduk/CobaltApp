﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Common;

namespace DAL.Entities
{
    /// <summary>
    /// The model for storage in the DB.
    /// </summary>
    public class UserAccount : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string HashOfPassword { get; set; }
    }
}
