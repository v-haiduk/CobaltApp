﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    public class ServerService : IServerService
    {
        private IUnitOfWork uow { get; set; }

        public ServerService(IUnitOfWork db)
        {
            this.uow = db;
        }

        /// <summary>
        /// The method gets all servers from DB and transfer them on PL
        /// </summary>
        public IEnumerable<ServerDTO> GetAllElements()
        {
            var allServers = uow.ServerRepository.GetAllElements();
            var allClusters = uow.ClusterRepository.GetAllElements();

            ServerDTO serv = new ServerDTO {};

            var test = from server in allServers
                       join cluster in allClusters 
                       on server.ClusterID equals cluster.Id
                            select new
                            {
                                ID = server.Id,
                                IPAdress = server.IPAdress,
                                SubnetMask = server.SubnetMask,
                                Subnetwork = server.Subnetwork,
                                NameOfCluster = cluster.Name
                           };
            List<ServerDTO> list = new List<ServerDTO>();
            foreach (var r in test)
            {
                ServerDTO serverDTO = new ServerDTO
                {
                    Id = r.ID,
                    IPAdress = r.IPAdress,
                    SubnetMask = r.SubnetMask,
                    Subnetwork = r.Subnetwork,
                    Cluster = r.NameOfCluster
                };
                list.Add(serverDTO);
            }

            return list;
        }


        /// <summary>
        /// The method gets the server from DB and transfer it on PL
        /// </summary>
        /// <param name="id">The id of server</param>
        public ServerDTO GetElement(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("??????", "");
            }
            var selectedServer = uow.ServerRepository.GetElement(id.Value);
            if (selectedServer == null)
            {
                throw new ValidationException("??????", "");

            }
            Mapper.Initialize(config => config.CreateMap<Server, ServerDTO>());


            return Mapper.Map<Server, ServerDTO>(selectedServer);
        }

        public IEnumerable<ServerDTO> FindElement(Expression<Func<ServerDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// The method gets the new server from PL and save it in DB
        /// </summary>
        /// <param name="item">Thew new server</param>
        public void Create(ServerDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("", "");
            }
            Mapper.Initialize(config => config.CreateMap<ServerDTO, Server>());
            var newServer = Mapper.Map<ServerDTO, Server>(item);
            uow.ServerRepository.Create(newServer);
            uow.SaveChanges();
        }


        /// <summary>
        /// The method gets the updated server from PL and save it in DB
        /// </summary>
        /// <param name="item">The updated server</param>
        public void Update(ServerDTO item) //CHECK THA AUTOMAPPING!!!
        {
            if (item == null)
            {
                throw new ValidationException("", "");
            }
            Mapper.Initialize(config => config.CreateMap<ServerDTO, Server>());
            var updatedServer = Mapper.Map<ServerDTO, Server>(item);
            uow.ServerRepository.Update(updatedServer);
            uow.SaveChanges();
        }

        /// <summary>
        /// The method gets the id of server from PL and delete it in DB
        /// </summary>
        /// <param name="id">The id of server for delete</param>
        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("", "");
            }
            uow.ServerRepository.Delete(id.Value);
            uow.SaveChanges();
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public int Count()
        {
            return uow.ServerRepository.GetAllElements().Count();
        }
    }
}
