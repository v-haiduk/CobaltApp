using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Common;

namespace BLL.Interfaces
{
    /// <summary>
    /// The interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IService<TEntity> //where TEntity : class IEntity
    {
        IEnumerable<TEntity> GetAllElements();
        TEntity GetElement(int? id);
        IEnumerable<TEntity> FindElement(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int? id);
        void Dispose();
    }
}
