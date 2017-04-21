using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CobaltApp.Models;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;

namespace CobaltApp.Controllers
{
    public class ClusterController : Controller
    {
        private IClusterService clusterService;

        public ClusterController(IClusterService service)
        {
            this.clusterService = service;
        }

        public ActionResult Index()
        {
            var listOfClusters = GetAllClusters();
            return View(listOfClusters);
        }

        [HttpGet]
        public ActionResult CreateCluster()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCluster(ClusterViewModel cluster)
        {
            Mapper.Initialize(config => config.CreateMap<ClusterViewModel, ClusterDTO>());
            var newCluster = Mapper.Map<ClusterViewModel, ClusterDTO>(cluster);
            clusterService.Create(newCluster);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCluster(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var clusterDTOForUpdate = clusterService.GetElement(id);
            if (clusterDTOForUpdate == null)
            {
                return HttpNotFound();
            }
            Mapper.Initialize(config => config.CreateMap<ClusterDTO, ClusterViewModel>());
            var cluserViewForUpdate = Mapper.Map<ClusterDTO, ClusterViewModel>(clusterDTOForUpdate);

            return View(cluserViewForUpdate);
        }

        [HttpPost]
        public ActionResult UpdateCluster(ClusterViewModel cluster)
        {
            Mapper.Initialize(config => config.CreateMap<ClusterViewModel, ClusterDTO>());
            var updatedCluster = Mapper.Map<ClusterViewModel, ClusterDTO>(cluster);
            clusterService.Update(updatedCluster);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteCluster(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            clusterService.Delete(id);

            return RedirectToAction("Index");
        }

        public IEnumerable<ClusterViewModel> GetAllClusters()
        {
            var clusters = clusterService.GetAllElements();
            Mapper.Initialize(config => config.CreateMap<ClusterDTO, ClusterViewModel>());
            var listOfClusters = Mapper.Map<IEnumerable<ClusterDTO>, List<ClusterViewModel>>(clusters);

            return listOfClusters;
        }

        
    }
}