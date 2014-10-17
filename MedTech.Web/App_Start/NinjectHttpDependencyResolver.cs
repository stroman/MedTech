﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace MedTech.Web.App_Start
{
    public class NinjectHttpDependencyResolver : IDependencyResolver, IDependencyScope
    {
        private readonly IKernel _kernel;
        public NinjectHttpDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            //Do nothing
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}