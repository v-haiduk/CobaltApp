using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            return RedirectToAction("Index");
        }


    }
}