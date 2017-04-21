using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Infrastructure;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;
using System.Security.Cryptography;

namespace BLL.Services
{
    /// <summary>
    /// The class implements the interface IUserService.
    /// </summary>
    public class UserService: IUserService
    {
        private IUnitOfWork uow { get; set; }

        //EFUnitOfWork will be used as the object of the IUnitOfWork
        public UserService(IUnitOfWork db)
        {
            uow = db;
        }

        /// <summary>
        /// The method gets all accounts of users from DB and transfer them on PL
        /// </summary>
        public IEnumerable<UserAccountDTO> GetAllElements()
        {
            var selectedUsers = uow.UserRepository.GetAllElements();
            Mapper.Initialize(config => config.CreateMap<UserAccount, UserAccountDTO>());

            return Mapper.Map<IEnumerable<UserAccount>, List<UserAccountDTO>>(selectedUsers);
        }

        /// <summary>
        /// The method gets the account of user from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of user</param>
        public UserAccountDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("?????", "");
            }
            var selectedUser = uow.UserRepository.GetElement(id.Value);
            if (selectedUser == null)
            {
                throw new ValidationException("??????", "");

            }
            Mapper.Initialize(config => config.CreateMap<UserAccount, UserAccountDTO>());

            return Mapper.Map<UserAccount, UserAccountDTO>(selectedUser);
        }

        /// <summary>
        /// The method finds a user by predicate
        /// </summary>
        /// <param name="predicate"></param>
        public IEnumerable<UserAccountDTO> FindElement(Expression<Func<UserAccountDTO, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            var predicateResult = predicate.Compile();
            var foundUsers = GetAllElements().Where(predicateResult);

            return foundUsers;
        }

        /// <summary>
        /// Method finds a user by login
        /// </summary>
        /// <param name="name">The user's login</param>
        public UserAccountDTO GetByLogin(string name)
        {
            var requestedUser = uow.UserRepository.FindElement(user => user.Name == name).FirstOrDefault();
            Mapper.Initialize(config => config.CreateMap<UserAccount, UserAccountDTO>());

            return Mapper.Map<UserAccount, UserAccountDTO>(requestedUser);
        }



        /// <summary>
        /// The method gets the new account of user from PL and save it in DB
        /// </summary>
        /// <param name="item">Thew new account</param>
        public void Create(UserAccountDTO item)
        {
            UserAccount user = new UserAccount
            {
                Name = item.Name,
                HashOfPassword = item.HashOfPassword
                //HashOfPasswrod = CreateHashOfPassword(item);
            };
            uow.UserRepository.Create(user);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the updated account of user from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated account</param>
        public void Update(UserAccountDTO item)
        {
            UserAccount user = new UserAccount
            {
                Id = item.Id,
                Name = item.Name,
                HashOfPassword = item.HashOfPassword ///ИЗМЕНИТЬ
            };
            uow.UserRepository.Update(user);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the id of user's account from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of account for delete</param>
        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("???", "");
            }

            uow.UserRepository.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public string CreateHashOfPassword(UserAccountDTO item)
        {
            throw new NotImplementedException();
            //byte[] saltValueBytes = Encoding.ASCII.GetBytes(item.Name);
            //byte[] passwordValueBytes = Encoding.ASCII.GetBytes(item.HashOfPassword);
            //PasswordDeriveBytes password = new PasswordDeriveBytes(passwordValueBytes, saltValueBytes, "SHA512", 5);

            //return password.ToString(); ///edit

        }
    }
}
