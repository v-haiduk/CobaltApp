using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using BLL.DTO;
using CobaltApp.Models;
using AutoMapper;

namespace CobaltApp.Controllers
{
    public class ServerController : Controller
    {
        private IServerService serverService;

        public ServerController(IServerService service)
        {
            this.serverService = service;
        }

        public ActionResult Index()
        {
            var listOfServers = GetAllServers();
            ViewBag.CountOfServers = GetAmountOfServers();

            return View(listOfServers);
        }

        [HttpGet]
        public ActionResult AddServer()
        {
            return View("AddServer");
        }

        [HttpPost]
        public ActionResult AddServer(ServerViewModel server)
        {
            Mapper.Initialize(config => config.CreateMap<ServerViewModel, ServerDTO>());
            var newServer = Mapper.Map<ServerViewModel, ServerDTO>(server);
            serverService.Create(newServer);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateServer(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var serverDTOForUpdate = serverService.GetElement(id);
            if (serverDTOForUpdate == null)
            {
                return HttpNotFound();
            }
            Mapper.Initialize(config => config.CreateMap<ServerDTO, ServerViewModel>());
            var serverViewForUpdate = Mapper.Map<ServerDTO, ServerViewModel>(serverDTOForUpdate);

            return View("", serverViewForUpdate);
        }

        [HttpPost]
        public ActionResult UpdateServer(ServerViewModel server)
        {
            Mapper.Initialize(config => config.CreateMap<ServerViewModel, ServerDTO>());
            var updatedServer = Mapper.Map<ServerViewModel, ServerDTO>(server);
            serverService.Update(updatedServer);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteServer(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            serverService.Delete(id);

            return RedirectToAction("Index");
        }

        public IEnumerable<ServerViewModel> GetAllServers()
        {
            var servers = serverService.GetAllElements();
            Mapper.Initialize(config => config.CreateMap<ServerDTO, ServerViewModel>());
            var listOfServers = Mapper.Map<IEnumerable<ServerDTO>, List<ServerViewModel>>(servers);

            return listOfServers;
        }

        [HttpGet]
        public ActionResult GetDescriptionOfServer(int? id)
        {
            var server = serverService.GetElement(id.Value);
            Mapper.Initialize(config => config.CreateMap<ServerDTO, ServerViewModel>());
            var serverForDisplay = Mapper.Map<ServerDTO, ServerViewModel>(server);

            return View("Profile", serverForDisplay);
        }

        public int GetAmountOfServers()
        {
            return serverService.Count();
        }
    }
}