using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BLL.Infrastructure;
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
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserAccountViewModel account)
        {
            Mapper.Initialize(config => config.CreateMap<UserAccountViewModel, UserAccountDTO>());
            var newAccount = Mapper.Map<UserAccountViewModel, UserAccountDTO>(account);
            userService.Create(newAccount);
            FormsAuthentication.SetAuthCookie(account.Name, true);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Authorization()
        {
            IEnumerable<UserAccountDTO> users = userService.GetAllElements();
            Mapper.Initialize(config => config.CreateMap<UserAccountDTO, UserAccountViewModel>());
            var listOfUsers = Mapper.Map<IEnumerable<UserAccountDTO>, List<UserAccountViewModel>>(users);

            return View(listOfUsers);
        }

        [HttpPost]
        public ActionResult Authorization(UserAccountViewModel account)
        {
            Mapper.Initialize(config => config.CreateMap<UserAccountViewModel, UserAccountDTO>());
            var newAccount = Mapper.Map<UserAccountViewModel, UserAccountDTO>(account);

            var resultOfAuthorizatuin = userService.FindElement(user => user.Name == newAccount.Name && 
                                                                        user.HashOfPassword == newAccount.HashOfPassword);

            if (resultOfAuthorizatuin != null)
            {
                FormsAuthentication.SetAuthCookie(account.Name, true);
                return RedirectToAction("Index"); //изменить страницу
            }
            else
            {
                ModelState.AddModelError("", "error! the password doen't correct!");
            }

            return View(account); 
        }


        //private void FullMappingOfModels(TE)
        //{
        //    Mapper.Initialize(config=> config.CreateMap<>)
        //}

    }
}