namespace Felice.Core.Boot
{
    using StructureMap.Configuration.DSL;

    public class FeliceRegistry : Registry
    {
        public FeliceRegistry()
        {
            Scan(x => x.AddAllTypesOf<IConfigurationBoot>());
        }
    }
}
