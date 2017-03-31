using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.Interfaces
{
    /// <summary>
    /// The interface is needed to work within the same business action.
    /// The data is expected, modified and saved on the end.
    /// The IDisposable is inherited for closed the connection.
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository userRepositories { get; }
        void SaveChanges();
    }
}
