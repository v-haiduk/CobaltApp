using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;


namespace DAL.Interfaces
{
    /// <summary>
    /// The generalized interface for work with DB.
    /// This interface encapsulates a logic to work with DB.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllElements();
        TEntity GetElement(int id);
        IEnumerable<TEntity> FindElement(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
    }
}
