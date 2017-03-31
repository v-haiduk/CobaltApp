using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BLL.Interfaces
{
    /// <summary>
    /// The interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IService<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAllElements();
        TEntity GetElement(int? id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int? id);
        void Dispose();
    }
}
