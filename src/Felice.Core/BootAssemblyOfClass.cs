namespace Felice.Core
{
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public abstract class BootAssemblyOfClass<T> : Registry
    {
        protected BootAssemblyOfClass()
        {
            this.Scan(x =>
            {
                x.AssemblyContainingType<T>();
                x.WithDefaultConventions();
                this.Execute(x);
            });
        }

        public abstract void Execute(IAssemblyScanner scan);
    }
}