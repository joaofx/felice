namespace Felice.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logs;
    using StructureMap;
    using Tasks;

    public class Dependency
    {
        public static void Initialize()
        {
            Log.Framework.InfoFormat("Initializing dependency resolver");

            ObjectFactory.Initialize(config =>
            {
                config.IgnoreStructureMapConfig = true;
                config.Scan(scan =>
                {
                    scan.AssembliesFromApplicationBaseDirectory();
                    scan.LookForRegistries();

                    scan.AddAllTypesOf<IFeliceTask>();
                });
            });
        }

        public static T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public static object Resolve(Type type)
        {
            if (type.IsAbstract || type.IsInterface)
            {
                return ObjectFactory.TryGetInstance(type);
            }

            return ObjectFactory.GetInstance(type);
        }

        public static IEnumerable<object> GetAll(Type type)
        {
            return ObjectFactory.GetAllInstances(type).Cast<object>();
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return ObjectFactory.GetAllInstances<T>();
        }

        public static void BuildUp(object obj)
        {
            ObjectFactory.BuildUp(obj);
        }
    }
}
