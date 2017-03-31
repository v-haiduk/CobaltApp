using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;

namespace DAL.Repositories
{
    /// <summary>
    /// The implementation of UserRepository
    /// </summary>
    public class UserAccountRepository: IUserRepository
    {
        private CobaltContext db;

        public UserAccountRepository(CobaltContext cobaltContext)
        {
            this.db = cobaltContext;
        }

        IEnumerable<UserAccount> IRepository<UserAccount>.GetAllElements()
        {
            return db.UserAccounts;
        }

        UserAccount IRepository<UserAccount>.GetElement(int id)
        {
            return db.UserAccounts.Find(id);
        }

        public void Create(UserAccount item)
        {
            db.UserAccounts.Add(item);
        }

        public void Update(UserAccount item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var userForDelete = db.UserAccounts.Find(id);
            if (userForDelete != null)
            {
                db.UserAccounts.Remove(userForDelete);
            }
        }

    }
}
