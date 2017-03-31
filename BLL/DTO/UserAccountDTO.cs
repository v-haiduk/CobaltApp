using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Entities;

namespace BLL.DTO
{
    /// <summary>
    /// The DTO (data transfer object) is intermediate class 
    /// for transfer of data between layers
    /// </summary>
    public class UserAccountDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HashOfPassword { get; set; }
    }
}
