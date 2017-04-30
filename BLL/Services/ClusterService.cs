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

namespace BLL.Services
{
    public class ClusterService : IClusterService
    {
        private IUnitOfWork uow;

        public ClusterService(IUnitOfWork db)
        {
            this.uow = db;
        }

        /// <summary>
        /// The method gets all clusters from DB and transfer them on PL
        /// </summary>
        public IEnumerable<ClusterDTO> GetAllElements()
        {
            var allClusters = uow.ClusterRepository.GetAllElements();
            Mapper.Initialize(config => config.CreateMap<Cluster, ClusterDTO>());

            return Mapper.Map<IEnumerable<Cluster>, List<ClusterDTO>>(allClusters);
        }


        /// <summary>
        /// The method gets the cluster from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of cluster</param>
        public ClusterDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
            }
            var selectedCluster = uow.ClusterRepository.GetElement(id.Value);
            if (selectedCluster == null)
            {
                throw new ValidationException("??????", "");
            }
            Mapper.Initialize(config => config.CreateMap<Cluster, ClusterDTO>());

            return Mapper.Map<Cluster, ClusterDTO>(selectedCluster);
        }

        public IEnumerable<ClusterDTO> FindElement(Expression<Func<ClusterDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// The method gets the new cluster from PL and save it in DB
        /// </summary>
        /// <param name="item">Thew new cluster</param>
        public void Create(ClusterDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("", "");
            }
            Mapper.Initialize(config => config.CreateMap<ClusterDTO, Cluster>());
            var newCluser = Mapper.Map<ClusterDTO, Cluster>(item);

            uow.ClusterRepository.Create(newCluser);
            uow.SaveChanges();
        }


        /// <summary>
        /// The method gets the updated cluster from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated cluster</param>
        public void Update(ClusterDTO item) //CHECK THA AUTOMAPPING!!!
        {
            if (item == null)
            {
                throw new ValidationException("", "");
            }
            Mapper.Initialize(config => config.CreateMap<ClusterDTO, Cluster>());
            var updatedCluser = Mapper.Map<ClusterDTO, Cluster>(item);

            uow.ClusterRepository.Update(updatedCluser);
            uow.SaveChanges();
        }


        /// <summary>
        /// The method gets the id of cluster from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of cluster for delete</param>
        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
            }
            uow.ClusterRepository.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public int Count()
        {
            return uow.ClusterRepository.GetAllElements().Count();
        }
    }
}
