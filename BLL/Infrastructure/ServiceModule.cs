﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Infrastructure
{
    /// <summary>
    /// The class for introduction of dependencies
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            this.connectionString = connection;
        }

        /// <summary>
        /// The method establishes dependecies.
        /// The EFUnitOfWorh use as the object IUnitOfWork
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
