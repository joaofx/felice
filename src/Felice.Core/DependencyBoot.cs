namespace Felice.Core
{
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public abstract class DependencyBoot<T> : Registry
    {
        protected DependencyBoot()
        {
            this.Scan(x =>
            {
                x.AssemblyContainingType<T>();
                x.WithDefaultConventions();
                this.Execute(x);
            });
        }

        public virtual void Execute(IAssemblyScanner scan)
        {
        }
    }
}