using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using BLL.Interfaces;
using BLL.Services;
using System.Web.Mvc;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace CobaltApp.Util
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kern)
        {
            kernel = kern;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IServerService>().To<ServerService>();
            kernel.Bind<IClusterService>().To<ClusterService>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

       
    }
}