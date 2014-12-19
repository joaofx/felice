namespace Demo.Boot
{
    using Felice.Core.Model;
    using Felice.Data;
    using StructureMap.Configuration.DSL;

    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}