using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Infrastructure;
using BLL.Interfaces;
using CobaltApp.Models;
using AutoMapper;

namespace CobaltApp.Controllers
{
    public class HomeController : Controller
    {
        private IServerService serverService;
        private IClusterService clusterService;
        private IUserService userService;

        public ActionResult Index()
        {
            
            return View();
        }

        public int[] StaticticInfo()
        {
            int[] staticticInfo = new int[3];
            staticticInfo[1] = serverService.Count();
            staticticInfo[2] = clusterService.Count();
            staticticInfo[3] = userService.Count();

            return staticticInfo;
        }
    }
}