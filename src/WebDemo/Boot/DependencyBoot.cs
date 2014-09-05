namespace WebDemo.Boot
{
    using Felice.Core;
    using Felice.Data;
    using Helpers;

    public class DependencyBoot : DependencyBoot<DependencyBoot>
    {
        public override void Execute(StructureMap.Graph.IAssemblyScanner scan)
        {
            this.For<IDatabaseProvider>().Use<PostgreDatabaseProvider>();
        }
    }
}
