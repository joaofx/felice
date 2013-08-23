namespace Felice.Core.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class StructureMapDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return Dependency.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Dependency.GetAll(serviceType);
        }
    }
}