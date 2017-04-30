using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Interfaces;
using BLL.DTO;
using CobaltApp.Models;
using AutoMapper;

namespace CobaltApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }

        public ActionResult Index()
        {
            var listOfUsers = GetAllUsers();
            ViewBag.CountOfUsers = GetAmountOfUsers();

            return View("Index", listOfUsers);
        }

        [HttpPost]
        public ActionResult Index(UserAccountViewModel account)
        {
            Registration(account);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Authorization()
        {         
            return View("Login");
        }

        [HttpPost]
        public ActionResult Authorization(UserAccountViewModel account)
        {
            var nameOfUser = account.Name;
            var resultOfFind = userService.GetByLogin(nameOfUser);
            if (resultOfFind != null)
            {
                if (account.HashOfPassword == resultOfFind.HashOfPassword)
                {
                    FormsAuthentication.SetAuthCookie(account.Name, true);
                    return RedirectToAction("Index");                           //change of page
                }
            }
            ModelState.AddModelError("", "error! the password doen't correct!");

            return View(account);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Profile(int? id)
        {
            var selectedUser = userService.GetElement(id);
            Mapper.Initialize(config => config.CreateMap<UserAccountDTO, UserAccountViewModel>());
            var profile = Mapper.Map<UserAccountDTO, UserAccountViewModel>(selectedUser);

            return View(profile);
        }

        [HttpGet]
        public ActionResult UpdateAccount(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var accountDTOForUpdate = userService.GetElement(id);
            Mapper.Initialize(config => config.CreateMap<UserAccountDTO, UserAccountViewModel>());
            var accountViewForUpdate = Mapper.Map<UserAccountDTO, UserAccountViewModel>(accountDTOForUpdate);
            if (accountViewForUpdate != null)
            {
                return View(accountViewForUpdate);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult UpdateAccount(UserAccountViewModel account)
        {
            Mapper.Initialize(config => config.CreateMap<UserAccountViewModel, UserAccountDTO>());
            var updatedAccount = Mapper.Map<UserAccountViewModel, UserAccountDTO>(account);
            userService.Update(updatedAccount);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteAccount(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            userService.Delete(id);

            return RedirectToAction("Index");
        }

        public void Registration(UserAccountViewModel account)
        {
            Mapper.Initialize(config => config.CreateMap<UserAccountViewModel, UserAccountDTO>());
            var newAccount = Mapper.Map<UserAccountViewModel, UserAccountDTO>(account);
            userService.Create(newAccount);
            FormsAuthentication.SetAuthCookie(account.Name, true);
        }

        public IEnumerable<UserAccountViewModel> GetAllUsers()
        {
            var users = userService.GetAllElements();
            Mapper.Initialize(config => config.CreateMap<UserAccountDTO, UserAccountViewModel>());
            var listOfUsers = Mapper.Map<IEnumerable<UserAccountDTO>, IEnumerable<UserAccountViewModel>>(users);

            return listOfUsers;
        }

        public int GetAmountOfUsers()
        {
            return userService.Count();
        }


    }
}