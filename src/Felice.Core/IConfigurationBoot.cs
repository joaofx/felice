namespace Felice.Core
{
    /// <summary>
    /// Runs before execute any action in the Boot Pipeline
    /// </summary>
    public interface IConfigurationBoot
    {
        void Execute();
    }
}