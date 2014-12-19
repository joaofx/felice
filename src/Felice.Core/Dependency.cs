namespace Felice.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Logs;
    using StructureMap;
    using StructureMap.Graph;
    using Tasks;
    using WebDemo.Boot;

    /// <summary>
    /// http://crosscuttingconcerns.com/StructureMap-3---some-changes-Ive-noticed
    /// http://buchanan1966.tumblr.com/post/2192279804/mvc3-using-dependencyresolver-with-structuremap
    /// http://www.khalidabuhakmeh.com/utilizing-structuremap-3-with-asp-net-mvc
    /// </summary>
    public class Dependency
    {
        public static Container Container
        {
            get;
            private set;
        }

        public static void Initialize()
        {
            Log.Framework.InfoFormat("Initializing dependency resolver");

            Container = new Container(config => config.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory();
                scan.LookForRegistries();

                scan.AddAllTypesOf<IFeliceTask>();
                scan.AddAllTypesOf<IConfigurationBoot>();
            }));
        } 

        public static T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public static object Resolve(Type type)
        {
            if (type.IsAbstract || type.IsInterface)
            {
                return Container.TryGetInstance(type);
            }

            return Container.GetInstance(type);
        }

        public static IEnumerable<object> GetAll(Type type)
        {
            return Container.GetAllInstances(type).Cast<object>();
        }

        public static IEnumerable<T> GetAll<T>()
        {
            return Container.GetAllInstances<T>();
        }

        public static void BuildUp(object obj)
        {
            Container.BuildUp(obj);
        }

        public static void SetupContainer(Container container)
        {
            Container = container;
        }
    }
}
